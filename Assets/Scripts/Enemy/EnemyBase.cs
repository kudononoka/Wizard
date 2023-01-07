using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Enemyの基底クラスです </summary>
public class EnemyBase : MonoBehaviour
{
    int _nowHp;
    [SerializeField] int _maxHp;
    PlayerLockon _lockon;
    /// <summary>Playerの近接攻撃からダメージを受けた場合のPlayerのMP回復量</summary>
    [SerializeField,Header("ダメージを受けた時のPlayerのMP回復量")] int _MPRecoveryAmount;
    // Start is called before the first frame update
    void Start()
    {
        _nowHp = _maxHp;
        _lockon = FindObjectOfType<PlayerLockon>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(int damage)
    {
        _nowHp -= damage;
        if(_nowHp < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerMasicObject"))
        {
            Damage(10);
        }
    }
}
