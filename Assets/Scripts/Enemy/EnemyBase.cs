using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Enemy�̊��N���X�ł� </summary>
public class EnemyBase : MonoBehaviour
{
    int _nowHp;
    [SerializeField] int _maxHp;

    /// <summary>Player�̋ߐڍU������_���[�W���󂯂��ꍇ��Player��MP�񕜗�</summary>
    [SerializeField,Header("�_���[�W���󂯂�����Player��MP�񕜗�")] int _MPRecoveryAmount;
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
