using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, InterfacePause
{
    Rigidbody _rb;
    
    [Tooltip("���s���x"), SerializeField] float _walkSpeed;
    
    [Tooltip("�����]�����x"), SerializeField] float _rotateSpeed;
    
    [Tooltip("�W�����v��"), SerializeField] float _jumpPower;
   
    [Tooltip("��𑬓x"), SerializeField] float _avoidanceSpeed;

    [Tooltip("Shield�ƂȂ�R���C�_�["),SerializeField] MeshCollider shield;

    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>Player�̑O��</summary>
    Quaternion _foward;

    /// <summary>�n�ʂ��痣�ꂽ��������d��</summary>
    [Header("�d��"), SerializeField] float _gravity;

    
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
            //�J������y���̃I�C���[�p���擾
            Quaternion _mainCamaraforward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up);
            _rb.velocity = _mainCamaraforward.normalized * new Vector3(x * _walkSpeed, 0, -z * _walkSpeed);

            if (_rb.velocity != Vector3.zero)
            {
                _foward = Quaternion.LookRotation(_rb.velocity, Vector3.up);
            }

            //���炩�ɉ�]������
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
                
                Debug.Log("���");
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
