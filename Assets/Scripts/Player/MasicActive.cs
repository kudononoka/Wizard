using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicActive : MonoBehaviour
{
    PlayerLockon _playerLookon;
    PlayerMasicAttack _playerMasicAttack;
    Vector3 _dir;
    Rigidbody _rb;
    float _moveSpeed;
    [SerializeField, Header("攻撃力")] float _attackPower;
    [SerializeField, Header("有利となる相手の属性")] GoAttribute _goAttribute;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        _playerMasicAttack = FindObjectOfType<PlayerMasicAttack>();
        _playerMasicAttack.MasicAction += Active;
        _playerLookon = FindObjectOfType<PlayerLockon>();
        _rb = GetComponent<Rigidbody>();
        _moveSpeed = 0;

    }

    

    private void OnDestroy()
    {
        _playerMasicAttack.MasicAction -= Active;
        
    }
    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _dir * _moveSpeed;
    }

    void Active()
    {
        if (_playerLookon.TargetPos != null)
        {
            Vector3 pos = _playerLookon.TargetPos.position;
            pos.y += 0.5f;
            _dir = pos - transform.position;
            _moveSpeed = _playerMasicAttack.MasicObjectMoveSpeed;
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("当たった");
            EnemyBase enemyBase = other.gameObject.GetComponent<EnemyBase>();
            if((int)enemyBase._attribute == (int)_goAttribute)
            {
                enemyBase.Damage((int)(_attackPower * 1.3f));
            }
            else
            {
                enemyBase.Damage((int)_attackPower);
            }
            
            if (enemyBase != null && enemyBase._isBoss)
            {
                enemyBase.SliderControlle();
            }
            Destroy(this.gameObject);
        }
    }

    public enum GoAttribute
    {
        Fire = 1,
        Ice = 2,
        Wind = 3,
        Thunder = 4,
    }
}
