using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Enemyの基底クラスです </summary>
public class EnemyBase : MonoBehaviour
{
    int _nowHp;
    [SerializeField] int _maxHp;

    /// <summary>Playerの近接攻撃からダメージを受けた場合のPlayerのMP回復量</summary>
    [SerializeField,Header("ダメージを受けた時のPlayerのMP回復量")] int _MPRecoveryAmount;
    // Start is called before the first frame update
    void Start()
    {
        _nowHp = _maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(int damage)
    {
        _nowHp -= damage;
    }
}
