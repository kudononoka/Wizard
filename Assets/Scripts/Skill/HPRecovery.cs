using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRecovery : PlayerSkillAction
{
    [SerializeField, Header("�񕜗�")] int _amount = 10;

    public override void Action()
    {
        FindObjectOfType<PlayerHPMP>().HPRecovery(_amount);
    }
}
