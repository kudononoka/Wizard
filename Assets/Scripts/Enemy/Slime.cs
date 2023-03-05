using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : EnemyBase
{
    [SerializeField,Header("SlimeKing���ǂ���")]
    [Tooltip("True��������SlimeKing�ł�")] bool _isBossSlime;
    [Tooltip("player�̈ʒu")] Transform _playerTra;
    [Tooltip("NormalAttack�̎���Player�Ƃ̋���")] float _isAttackDistance;
    [SerializeField, Tooltip("�퓬����Player�Ƃ̍ō�����")] float _isBattleDistance;
    [Tooltip("�퓬�����ǂ����ETrue��������퓬���Ă���")] bool _isBattle = false;
    [Tooltip("�퓬���̍U�����邽�߂̎��ԊǗ��p")] float _attackTimer;
    [SerializeField,Tooltip("�퓬���̍U���J�n����")] float _attackTime;

    NavMeshAgent _agent;
    Animator _anim;
    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
        _agent = GetComponent<NavMeshAgent>();  
        _anim = GetComponent<Animator>();
        //�ŏ���Player��Transform�擾
        _playerTra = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(_playerTra.position, this.transform.position);
        //Player���퓬�͈͓��ɓ�������
        if(_isBattleDistance >= dis)
        {
            //�퓬��Ԃɂ���
            state = State.IsBattle;
        }
        //Player���퓬�͈͊O�ɂ��ăo�g������������
        else 
        {
            state = State.Normal;
        }

        //HP��0�ɂȂ����玀��Ԃɂ���
        if(_nowHp < 0)
        {
            state = State.Deth;
        }

        switch(state)
        {
            case State.Normal:
                _agent.SetDestination(this.transform.position);
                break;

            //�퓬��Ԃ�������
            case State.IsBattle:
                //�U���͈͓���Player��������
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
            //����Ԃ�������
            case State.Deth:
                Destroy(this.gameObject);
                break;
        }

        _anim.SetFloat("Walk", _agent.velocity.magnitude);
    }

    /// <summary>���̏�ԊǗ��p��enum</summary>
    enum State
    {
        /// <summary>���ʂ̏��</summary>
        Normal,
        /// <summary>�퓬��</summary>
        IsBattle,
        /// <summary>��</summary>
        Deth,
    }
}
