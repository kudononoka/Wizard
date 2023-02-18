using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GroundJudgment))]

public class PlayerMove : MonoBehaviour, InterfacePause
{
    Rigidbody _rb;
    Animator _anim;
    
    [Tooltip("歩行速度"), SerializeField] float _walkSpeed;
    
    [Tooltip("方向転換速度"), SerializeField] float _rotateSpeed;
    
    [Tooltip("ジャンプ力"), SerializeField] float _jumpPower;
   
    [Tooltip("回避速度"), SerializeField] float _avoidanceSpeed;

    [Tooltip("shieldとなるオブジェクト"), SerializeField] GameObject _shield;

    [SerializeField] Transform _afterAvoidancePos;

    [SerializeField, Header("コントローラー操作かどうか"), Tooltip("Trueの時コントローラー操作用")] bool _isController; 

    Vector3 _savePos;

    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>Playerの前方</summary>
    Quaternion _foward;

    /// <summary>地面から離れた時かける重力</summary>
    [Header("重力"), SerializeField] float _gravity;

    Vector3 _velo;
    GroundJudgment _groundJudgment;
    
    bool _ispos;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _mainCamera = Camera.main.gameObject;
        _groundJudgment = GetComponent<GroundJudgment>();
    }

    
    void Update()
    {
        float x = _isController ? Input.GetAxisRaw("HorizontalController") : Input.GetAxisRaw("Horizontal");
        float z = _isController ? Input.GetAxisRaw("VerticalController") : Input.GetAxisRaw("Vertical");

        
            //カメラのy軸のオイラー角を取得
        Quaternion _mainCamaraforward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up);
        _rb.velocity = _mainCamaraforward.normalized * new Vector3(x * _walkSpeed, 0, z * _walkSpeed);

        if (_rb.velocity != Vector3.zero)
        {
            _foward = Quaternion.LookRotation(_rb.velocity, Vector3.up);
        }
        _anim.SetFloat("Walk", _rb.velocity.magnitude);

        //滑らかに回転させる
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _foward, _rotateSpeed * Time.deltaTime);
        if (_groundJudgment.IsGround)
        {
            if (Input.GetButtonDown("JumpController"))
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }
        else
        {
            _rb.AddForce(Vector3.down * _gravity);
        }

        if(Input.GetKey(KeyCode.G))
        {
            _anim.SetBool("gard", true);
            _rb.Sleep();
            _shield.SetActive(true);
        }
        else
        {
            _rb.WakeUp();
            _shield.SetActive(false);
            _anim.SetBool("gard", false);
        }

        if (Input.GetButton("AvoidanceController") || Input.GetKeyDown(KeyCode.V))
        {
            if (_ispos)
            {
                _savePos = _afterAvoidancePos.position;
                _ispos = false;
            }
            //_anim.SetBool("avoid", true);
            //transform.position = Vector3.MoveTowards(transform.position, _savePos, _avoidanceSpeed * Time.deltaTime);
            //if (transform.position == _savePos)
            //{
            //    _anim.SetBool("avoid", false);
            //}

            _anim.SetTrigger("Avoid");



            //StartCoroutine(Avoid());    
        }
        else
        {
            _ispos = true;
        }
        
        
        
        
        if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Avoid"))
        {
            transform.position = Vector3.MoveTowards(transform.position, _savePos, _avoidanceSpeed * Time.deltaTime);
        }

        
    }

    //IEnumerator Avoid()
    //{

    //    _anim.SetBool("avoid", true);
    //    transform.position = Vector3.MoveTowards(transform.position, _savePos, _avoidanceSpeed * Time.deltaTime);
    //    yield return new WaitForSeconds(2);
    //    _anim.SetBool("avoid", false);
    //}
    void InterfacePause.Pause()
    {
        _walkSpeed = 0;
    }
    void InterfacePause.Resume()
    {
        _walkSpeed = 10;
    }

    
}
