using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : EnemyBase
{
    [SerializeField,Header("SlimeKingかどうか")]
    [Tooltip("TrueだったらSlimeKingです")] bool _isBossSlime;
    [Tooltip("playerの位置")] Transform _playerTra;
    [Tooltip("NormalAttackの時のPlayerとの距離")] float _isAttackDistance;
    [SerializeField, Tooltip("戦闘時のPlayerとの最高距離")] float _isBattleDistance;
    [Tooltip("戦闘中かどうか・Trueだったら戦闘している")] bool _isBattle = false;
    [Tooltip("戦闘中の攻撃するための時間管理用")] float _attackTimer;
    [SerializeField,Tooltip("戦闘中の攻撃開始時間")] float _attackTime;

    NavMeshAgent _agent;
    Animator _anim;
    State state;
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
        float dis = Vector3.Distance(_playerTra.position, this.transform.position);
        //Playerが戦闘範囲内に入ったら
        if(_isBattleDistance >= dis)
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
                //攻撃範囲内にPlayerがいたら
                if(_agent.stoppingDistance >= dis)
                {
                    _attackTimer += Time.deltaTime;
                    if(_attackTimer > _attackTime)
                    {
                        _anim.SetTrigger("Attack");
                        _attackTimer = 0;
                    }
                }
                else
                {
                    _attackTimer = 0;
                    _agent.SetDestination(_playerTra.position);
                }

                break;
            //死状態だったら
            case State.Deth:
                Destroy(this.gameObject);
                break;
        }

        _anim.SetFloat("Walk", _agent.velocity.magnitude);
    }

    /// <summary>今の状態管理用のenum</summary>
    enum State
    {
        /// <summary>普通の状態</summary>
        Normal,
        /// <summary>戦闘中</summary>
        IsBattle,
        /// <summary>死</summary>
        Deth,
    }
}
