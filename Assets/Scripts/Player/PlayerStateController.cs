using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateController : MonoBehaviour
{
    public SkillState _playerSkillState;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>Playerのskill使用の状態を管理するビットフラグです</summary>
    [Flags]
    public enum SkillState
    {
        /// <summary>攻撃力UPスキル</summary>
        AttackPowerUp = 1 << 0,
        /// <summary>HP回復スキル</summary>
        HPRecovery = 1 << 1,
        /// <summary>ダメージ0シールド発動スキル</summary>
        ShieldOn = 1 << 2,
    }

}
