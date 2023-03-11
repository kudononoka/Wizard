using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Slime : EnemyBase
{
    [Tooltip("player�̈ʒu")] Transform _playerTra;
    [Tooltip("NormalAttack�̎���Player�Ƃ̋���")] float _isAttackDistance;
    [SerializeField, Tooltip("�퓬����Player�Ƃ̍ō�����")] float _isBattleDistance;
    [Tooltip("�퓬���̍U�����邽�߂̎��ԊǗ��p")] float _attackTimer;
    [SerializeField,Tooltip("�퓬���̍U���J�n����")] float _attackTime;
    [SerializeField, Header("�U���p�̃I�u�W�F�N�gPrefab")] GameObject _attackGOPrefab;
    NavMeshAgent _agent;
    Animator _anim;
    [SerializeField]public State state;
    float dis;

    /// SlimeBoss�̂��߂̍U��Intervaltime�p�̕ϐ�
    [SerializeField, Header("slime�����J�n����")] float _slimeInstanceTime;
    float _slimeInstanceTimer;
    [SerializeField, Header("slimePrefab")] GameObject _slimePrefab;
    [SerializeField, Header("slime�����ꏊ")] Transform[] _spawnPoint;
    [SerializeField] PlayerLockon _lockon;
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
        dis = Vector3.Distance(_playerTra.position, this.transform.position);
        //Player���퓬�͈͓��ɓ�������
        if(dis <= _isBattleDistance)
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
            //����Ԃ�������
            case State.Deth:
                Destroy(this.gameObject);
                break;
        }

        _anim.SetFloat("Walk", _agent.velocity.magnitude);

        //�{�X���o�g������������
        if (state == State.IsBattle && _isBoss)
        {
            //�{�X��p��Slider��\��
            _bossSlider.SetActive(true);
        }
    }

    /// <summary>���̏�ԊǗ��p��enum</summary>
    public enum State
    {
        /// <summary>���ʂ̏��</summary>
        Normal,
        /// <summary>�퓬��</summary>
        IsBattle,
        /// <summary>��</summary>
        Deth,
    }
    private void Attack()
    {
        //�U���͈͓���Player��������
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
