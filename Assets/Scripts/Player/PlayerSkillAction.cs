using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkillAction : MonoBehaviour
{
    [SerializeField, Header("SPè¡îÔó ")] int _spConsumption;
    MPUIManager _mpUIManager;
    public abstract void Action();

    private void Awake()
    {
        _mpUIManager = GameObject.Find("MP").GetComponent<MPUIManager>();
    }
    public void SkillAction()
    {
        _mpUIManager.Consumption(_spConsumption);
        Action();
    }
}
