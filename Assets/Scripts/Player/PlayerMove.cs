using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, InterfacePause
{
    Rigidbody _rb;
    
    [Tooltip("歩行速度"), SerializeField] float _walkSpeed;
    
    [Tooltip("方向転換速度"), SerializeField] float _rotateSpeed;
    
    [Tooltip("ジャンプ力"), SerializeField] float _jumpPower;
   
    [Tooltip("回避速度"), SerializeField] float _avoidanceSpeed;

    [Tooltip("Shieldとなるコライダー"),SerializeField] MeshCollider shield;

    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>Playerの前方</summary>
    Quaternion _foward;

    /// <summary>地面から離れた時かける重力</summary>
    [Header("重力"), SerializeField] float _gravity;

    
    Vector3 velo;
    GroundJudgment groundJudgment;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main.gameObject;
        groundJudgment = GetComponent<GroundJudgment>();
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("HorizontalController");
        float z = Input.GetAxisRaw("VerticalController");

        if (groundJudgment.IsGround)
        {
            //カメラのy軸のオイラー角を取得
            Quaternion _mainCamaraforward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up);
            _rb.velocity = _mainCamaraforward.normalized * new Vector3(x * _walkSpeed, 0, -z * _walkSpeed);

            if (_rb.velocity != Vector3.zero)
            {
                _foward = Quaternion.LookRotation(_rb.velocity, Vector3.up);
            }

            //滑らかに回転させる
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _foward, _rotateSpeed * Time.deltaTime);

            if(Input.GetButtonDown("JumpController"))
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }

            if(Input.GetButton("Shield"))
            {
                shield.enabled = true;
            }
            else
            {
                shield.enabled = false; 
            }

            if(Input.GetButtonDown("AvoidanceController"))
            {
                
                Debug.Log("回避");
                if (_rb.velocity != Vector3.zero)
                {
                    velo = _rb.velocity;
                    //transform.position = Vector3.MoveTowards(transform.position, transform.position + _rb.velocity * 200, _avoidanceSpeed * Time.deltaTime);
                    StartCoroutine(Avoid());
                }
                
            }
        }
        else
        {
            _rb.AddForce(Vector3.down * _gravity);
        }
    }

    void InterfacePause.Pause()
    {
        _walkSpeed = 0;
    }
    void InterfacePause.Resume()
    {
        _walkSpeed = 10;
    }

    IEnumerator Avoid()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + velo * 200, _avoidanceSpeed * Time.deltaTime);
        _walkSpeed = 0;
        yield return new WaitForSeconds(1);
        _walkSpeed = 10;
        
        
    }
}
