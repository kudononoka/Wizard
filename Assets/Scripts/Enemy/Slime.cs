using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Slime : EnemyBase
{
    [Tooltip("playerの位置")] Transform _playerTra;
    [Tooltip("NormalAttackの時のPlayerとの距離")] float _isAttackDistance;
    [SerializeField, Tooltip("戦闘時のPlayerとの最高距離")] float _isBattleDistance;
    [Tooltip("戦闘中の攻撃するための時間管理用")] float _attackTimer;
    [SerializeField,Tooltip("戦闘中の攻撃開始時間")] float _attackTime;
    [SerializeField, Header("攻撃用のオブジェクトPrefab")] GameObject _attackGOPrefab;
    NavMeshAgent _agent;
    Animator _anim;
    [SerializeField]public State state;
    float dis;

    /// SlimeBossのための攻撃Intervaltime用の変数
    [SerializeField, Header("slime生成開始時間")] float _slimeInstanceTime;
    float _slimeInstanceTimer;
    [SerializeField, Header("slimePrefab")] GameObject _slimePrefab;
    [SerializeField, Header("slime生成場所")] Transform[] _spawnPoint;
    [SerializeField] PlayerLockon _lockon;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
        _agent = GetComponent<NavMeshAgent>();  
        _anim = GetComponent<Animator>();
        //最初にPlayerのTransform取得
        _playerTra = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(_playerTra.position, this.transform.position);
        //Playerが戦闘範囲内に入ったら
        if(dis <= _isBattleDistance)
        {
            //戦闘状態にする
            state = State.IsBattle;
        }
        //Playerが戦闘範囲外にいてバトル中だったら
        else 
        {
            state = State.Normal;
        }

        //HPが0になったら死状態にする
        if(_nowHp < 0)
        {
            state = State.Deth;
        }

        switch(state)
        {
            case State.Normal:
                _agent.SetDestination(this.transform.position);
                break;

            //戦闘状態だったら
            case State.IsBattle:
                if(_isBoss)
                {
                    _slimeInstanceTimer += Time.deltaTime;
                    if(_slimeInstanceTimer > _slimeInstanceTime)
                    {
                        int attackPattern = Random.Range(0, 10);
                        if (attackPattern <= 2)
                        {
                            _anim.SetTrigger("BossAttack");
                            _slimeInstanceTimer = 0;
                        }
                        else
                        {
                            Attack();
                        }
                    }
                    
                }
                else
                {
                    Attack();
                }
                break;
            //死状態だったら
            case State.Deth:
                Destroy(this.gameObject);
                break;
        }

        _anim.SetFloat("Walk", _agent.velocity.magnitude);

        //ボスがバトル中だったら
        if (state == State.IsBattle && _isBoss)
        {
            //ボス専用のSliderを表示
            _bossSlider.SetActive(true);
        }
    }

    /// <summary>今の状態管理用のenum</summary>
    public enum State
    {
        /// <summary>普通の状態</summary>
        Normal,
        /// <summary>戦闘中</summary>
        IsBattle,
        /// <summary>死</summary>
        Deth,
    }
    private void Attack()
    {
        //攻撃範囲内にPlayerがいたら
        if (_agent.stoppingDistance >= dis)
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer > _attackTime)
            {
                _anim.SetTrigger("Attack");
                _attackTimer = 0;
                _slimeInstanceTimer = 0;
            }
        }
        else
        {
            _attackTimer = 0;
            _slimeInstanceTimer = 0;
            _agent.SetDestination(_playerTra.position);
        }
    }
    private void SlimeInstance()
    {
        foreach (var spawnPos in _spawnPoint)
        {
            Instantiate(_slimePrefab, spawnPos.position, Quaternion.identity);
        }
    }
    private void AttackObjectInstance()
    {
        Instantiate(_attackGOPrefab, transform.position, Quaternion.identity);
    }

    
}
