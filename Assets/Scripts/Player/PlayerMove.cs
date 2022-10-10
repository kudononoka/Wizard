using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    /// <summary>���s���x</summary>
    [Header("���s���x"), SerializeField] float _walkSpeed;
    /// <summary>�����]�����x</summary>
    [Header("�����]�����x"), SerializeField] float _rotateSpeed;

    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>Player�̑O��</summary>
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

        //�J������y���̃I�C���[�p���擾
        Quaternion  _mainCamaraforward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up); 
        _rb.velocity = _mainCamaraforward.normalized * new Vector3(x * _walkSpeed, 0, z * _walkSpeed);

        if(_rb.velocity != Vector3.zero)
        {
            _foward = Quaternion.LookRotation(_rb.velocity,Vector3.up);
        }
        
        //���炩�ɉ�]������
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _foward, _rotateSpeed * Time.deltaTime);
    }
}
