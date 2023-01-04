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

    private void OnDisable()
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
        _dir = _playerLookon.TargetPos.position - transform.position;
        _moveSpeed = _playerMasicAttack.MasicObjectMoveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
