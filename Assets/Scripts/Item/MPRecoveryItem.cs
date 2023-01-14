using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPRecoveryItem : ItemBase
{
    [SerializeField] int _amount;
    public override void Action()
    {
        FindObjectOfType<PlayerHPMP>().SPRecovery(_amount);
    }
}
