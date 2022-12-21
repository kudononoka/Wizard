using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPMP : MonoBehaviour
{
    [SerializeField] Slider _slider;
    int _nowHp;
    [SerializeField] int _maxHp;
    int _nowMp;
    [SerializeField] int _maxMp;
    [SerializeField, Header("�t���ς̖���")] int _reafNum;
    
    GridLayoutGroup _gridLayoutGroup;
    int _costMPAmount;
    public int ReafNum { get { return _reafNum; }}

    public int CostMPAmount { get { return _costMPAmount; } }
    void Start()
    {
        _nowHp = _maxHp;
        
        _gridLayoutGroup = GameObject.Find("MP").GetComponent<GridLayoutGroup>();
        _gridLayoutGroup.constraintCount = _reafNum;
        _maxMp = _reafNum * 2;
        _nowMp = _maxMp;
    }

    
    /// <param name="damage">�󂯂��_���[�W��</param>
    public void HPDamage(int damage)
    {
        _nowHp -= damage;
    }

    /// <param name="amount">�񕜗�</param>
    public void HPRecovery(int amount)
    {
        _nowHp += amount;
    }

    /// <param name="amount">�����</param>
    public void MPConsumption(int amount)
    {
        _costMPAmount = amount;
    }

    /// <param name="amount">�񕜗�</param>
    public void MPRecovery(int amount)
    {
        _nowMp += amount;
    }

    void MPChangeValue()
    {

    }
}
