using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackObjectMove : MonoBehaviour
{
    
    /// <summary>�ڕW�̈ʒu</summary>
    Vector3 _targetPos;
    Rigidbody _rb;
    /// <summary>�ˏo���̊p�x</summary>
    [SerializeField,Header("�ˏo���̊p�x")] float _angle;
    // Start is called before the first frame update
    void Start()
    {
        _targetPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        _rb = GetComponent<Rigidbody>();
        Move();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        //�����x�����߂�
        Vector3 vel = CalculationOfInitialvelocity(_targetPos, transform.position, _angle);
        //�^�����������mass��ς����Ƃ��Ă����������ɂ���
        _rb.AddForce(vel * _rb.mass, ForceMode.Impulse);
    }

    Vector3 CalculationOfInitialvelocity(Vector3 targetPos, Vector3 thisPos, float angle)
    {
        //���W�A���ɕϊ�
        float rad = angle * Mathf.PI / 180;
        //�����������̋���
        float disX = Vector2.Distance(new Vector2(targetPos.x, targetPos.z), new Vector2(thisPos.x, thisPos.z));
        //�����������̋���
        float y = targetPos.y - thisPos.y;
        //�Ε����˂̌����������ď����x�����߂�
        float speed = Mathf.Sqrt(Physics.gravity.y * Mathf.Pow(disX, 2) / ((y - disX * Mathf.Tan(rad)) * 2 * Mathf.Pow(Mathf.Cos(rad), 2)));
        
        return new Vector3(targetPos.x - thisPos.x, disX * Mathf.Tan(rad), targetPos.z - thisPos.z).normalized * speed;
        
    }
    
}
