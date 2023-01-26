﻿using System.Collections;
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



        if (Input.GetButton("AvoidanceController"))
        {
            if (_ispos)
            {
                   
                _savePos = _afterAvoidancePos.position;
                _ispos = false;

            }
                
            transform.position = Vector3.MoveTowards(transform.position, _savePos, _avoidanceSpeed * Time.deltaTime);
        }
        else
        {
            _ispos = true;
        }
        

        if (_anim != null)
        {
            _anim.SetFloat("walk", _rb.velocity.magnitude);
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

    
}
