using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shield : PlayerSkillAction
{
    /// <summary>シールドを表示する時間</summary>
    [SerializeField, Header("シールドを表示する時間")] float _time;

    [SerializeField,Header("シールドのコライダーを持つGameObject")] GameObject　_shieldGameObject;

    Button _button;
    private void Start()
    {
        _shieldGameObject.SetActive(false);
        _button = GetComponent<Button>();
    }
    public override void Action()
    {
        StartCoroutine(ShieldActive());
    }

    IEnumerator ShieldActive()
    {
        _button.interactable = false;
        _shieldGameObject.SetActive(true);
        yield return new WaitForSeconds(_time);
        _shieldGameObject.SetActive(false);
        _button.interactable = true;
    }
}
