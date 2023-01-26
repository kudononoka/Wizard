using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    Rigidbody _rb;
    NavMeshAgent _agent;
    /// <summary>目的地となるposition</summary>
    Transform _targetTrans;
    GroundJudgment _groundJudgment;
    [SerializeField,Header("ジャンプした時の重力")]float _gravity = 9.8f;
    [SerializeField, Header("ジャンプした時の初速度")] float _setSpeed = 10f;
    bool _isJump = false;
    int _jumpCount = 0;
    [SerializeField] float _time = 10;
    Vector3 lookdir;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _targetTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();  
        _groundJudgment = GetComponent<GroundJudgment>();
        
        _isJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //_agent.SetDestination(_targetTrans.position);

        if (_isJump)
        {
            _agent.updatePosition = false;
            _agent.nextPosition = transform.position;
            
            Jump();
        }
        else
        {
            _agent.SetDestination(_targetTrans.position);
            
        }

        if (!_agent.updatePosition)
        {
            lookdir = _targetTrans.position - transform.position;
            lookdir.y = 0;
            transform.rotation = Quaternion.LookRotation(lookdir);
        }
    }

    void Jump()
    {
        _time += Time.deltaTime;
        float angle = Vector3.Angle(transform.forward, transform.up);
        float zSpeed = _setSpeed * Mathf.Cos(angle);
        float ySpeed = _setSpeed * Mathf.Sin(angle) - _gravity * _time;
        _rb.velocity = transform.rotation * new Vector3(0, ySpeed, -zSpeed);
        if(_rb.velocity.y < 0)
        {
            _gravity += 0.03f;
        }

        if(_groundJudgment.IsGround && _rb.velocity.y < 0)
        {
            _agent.updatePosition = true;
            _rb.isKinematic = true;
            _time = 0;
            _isJump = !_isJump;
        }
    }
}
