using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRecoveryItem : ItemBase
{
    [SerializeField] int _amount;
    public override void Action()
    {
        FindObjectOfType<PlayerHPMP>().HPRecovery(_amount);
    }
}
