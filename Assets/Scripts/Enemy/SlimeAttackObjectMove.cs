using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackObjectMove : MonoBehaviour
{
    
    /// <summary>目標の位置</summary>
    Vector3 _targetPos;
    Rigidbody _rb;
    /// <summary>射出時の角度</summary>
    [SerializeField,Header("射出時の角度")] float _angle;
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
        //初速度を求める
        Vector3 vel = CalculationOfInitialvelocity(_targetPos, transform.position, _angle);
        //運動方程式よりmassを変えたとしても同じ挙動にする
        _rb.AddForce(vel * _rb.mass, ForceMode.Impulse);
    }

    Vector3 CalculationOfInitialvelocity(Vector3 targetPos, Vector3 thisPos, float angle)
    {
        //ラジアンに変換
        float rad = angle * Mathf.PI / 180;
        //水平方向ｘの距離
        float disX = Vector2.Distance(new Vector2(targetPos.x, targetPos.z), new Vector2(thisPos.x, thisPos.z));
        //垂直方向ｙの距離
        float y = targetPos.y - thisPos.y;
        //斜方投射の公式をつかって初速度を求める
        float speed = Mathf.Sqrt(Physics.gravity.y * Mathf.Pow(disX, 2) / ((y - disX * Mathf.Tan(rad)) * 2 * Mathf.Pow(Mathf.Cos(rad), 2)));
        
        return new Vector3(targetPos.x - thisPos.x, disX * Mathf.Tan(rad), targetPos.z - thisPos.z).normalized * speed;
        
    }
    
}
