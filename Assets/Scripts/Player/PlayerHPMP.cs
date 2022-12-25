using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPMP : MonoBehaviour
{
    [SerializeField] Slider _sliderHp;
    int _nowHp;
    [SerializeField] int _maxHp;
    int _nowMp;
    [SerializeField] int _maxMp;

    int _minHp = 0;
    [SerializeField, Header("葉っぱの枚数")] int _reafNum;
    
    GridLayoutGroup _gridLayoutGroup;
    int _costMPAmount;
    public int ReafNum { get { return _reafNum; }}

    public int CostMPAmount { get { return _costMPAmount; } }
    void Start()
    {
        _nowHp = _maxHp;
        _sliderHp.maxValue = _nowHp;
        _sliderHp.minValue = _minHp;
        _sliderHp.value = _nowHp;
        _gridLayoutGroup = GameObject.Find("MP").GetComponent<GridLayoutGroup>();
        _gridLayoutGroup.constraintCount = _reafNum;
        _maxMp = _reafNum * 2;
        _nowMp = _maxMp;
    }

    
    /// <param name="damage">受けたダメージ数</param>
    public void HPDamage(int damage)
    {
        _nowHp -= damage;
        _sliderHp.value = _nowHp;
        if (_nowHp < _minHp)
        {

        }
    }

    /// <param name="amount">回復量</param>
    public void HPRecovery(int amount)
    {
        _nowHp += amount;
        if(_nowHp > _maxHp)
        {
            _nowHp = _maxHp;
        }
        _sliderHp.value = _nowHp;
    }

    /// <param name="amount">消費量</param>
    public void MPConsumption(int amount)
    {
        _costMPAmount = amount;
    }

    /// <param name="amount">回復量</param>
    public void MPRecovery(int amount)
    {
        _nowMp += amount;
    }
}
