using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerHPMP : MonoBehaviour
{
    public PlayerState _playerState = PlayerState.Normal;
    [SerializeField] Slider _sliderHp;
    int _nowHp;
    [SerializeField] int _maxHp;
    int _nowSp;
    [SerializeField] int _maxSp;

    int _minHp = 0;
    [SerializeField, Header("葉っぱの枚数")] int _reafNum;
    
    GridLayoutGroup _gridLayoutGroup;
    int _costSPAmount;
    public int ReafNum => _reafNum;

    public int CostSPAmount { get { return _costSPAmount; } }
    void Start()
    {
        _nowHp = _maxHp;
        _sliderHp.maxValue = _nowHp;
        _sliderHp.minValue = _minHp;
        _sliderHp.value = _nowHp;
        _gridLayoutGroup = GameObject.Find("MP").GetComponent<GridLayoutGroup>();
        _gridLayoutGroup.constraintCount = _reafNum;
        _maxSp = _reafNum * 2;
        _nowSp = _maxSp;
    }

    private void Update()
    {
        
    }

    /// <param name="damage">受けたダメージ数</param>
    public void HPDamage(int damage)
    {
        _nowHp -= damage;
        _sliderHp.value = _nowHp;
        if (_nowHp < _minHp)
        {
            ChangeSceneManager changeScene = GameObject.Find("SceneManager").GetComponent<ChangeSceneManager>();
            changeScene.ChangeScene("GameOver");
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
    public void SPConsumption(int amount)
    {
        _costSPAmount = amount;
    }

    /// <param name="amount">回復量</param>
    public void SPRecovery(int amount)
    {
        _nowSp += amount;
    }

    /// <summary>現在のPlayerの状態管理用のenum・PlayerHPMPスクリプトに書くほうがいいのか</summary>
    [Flags]
    public enum PlayerState
    {
        Normal = 1 << 0,
        Burn = 1 << 1,
        Poison = 1 << 2,
    }
}
