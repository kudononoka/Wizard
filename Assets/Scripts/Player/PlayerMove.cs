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

    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>Playerの前方</summary>
    Quaternion _foward;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main.gameObject;
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //カメラのy軸のオイラー角を取得
        Quaternion  _mainCamaraforward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up); 
        _rb.velocity = _mainCamaraforward.normalized * new Vector3(x * _walkSpeed, 0, z * _walkSpeed);

        if(_rb.velocity != Vector3.zero)
        {
            _foward = Quaternion.LookRotation(_rb.velocity,Vector3.up);
        }
        
        //滑らかに回転させる
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _foward, _rotateSpeed * Time.deltaTime);
    }
}
