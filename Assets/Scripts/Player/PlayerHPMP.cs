using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPMP : MonoBehaviour
{
    int _nowHp;
    [SerializeField] int _maxHp;
    int _nowMp;
    [SerializeField] int _maxMp;
    
    void Start()
    {
        _nowHp = _maxHp;
        _nowMp = _maxMp;
    }

    
    /// <param name="damage">ó‚¯‚½ƒ_ƒ[ƒW”</param>
    public void HPDamage(int damage)
    {
        _nowHp -= damage;
    }

    /// <param name="amount">‰ñ•œ—Ê</param>
    public void HPRecovery(int amount)
    {
        _nowHp += amount;
    }

    /// <param name="amount">Á”ï—Ê</param>
    public void MPConsumption(int amount)
    {
        _nowMp -= amount;
    }

    /// <param name="amount">‰ñ•œ—Ê</param>
    public void MPRecovery(int amount)
    {
        _nowMp += amount;
    }
}
