using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    /// <summary>歩行速度</summary>
    [Header("歩行速度"), SerializeField] float _walkSpeed;
    /// <summary>方向転換速度</summary>
    [Header("方向転換速度"), SerializeField] float _rotateSpeed;
    /// <summary>ジャンプ力</summary>
    [Header("ジャンプ力"), SerializeField] float _jumpPower;

    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>Playerの前方</summary>
    Quaternion _foward;

    /// <summary>地面から離れた時かける重力</summary>
    [Header("重力"), SerializeField] float _gravity;

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
        }
        else
        {
            _rb.AddForce(Vector3.down * _gravity);
        }
    }
}
