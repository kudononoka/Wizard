using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMasicAttack : MonoBehaviour
{
    [SerializeField, Header("魔法を生成する場所")] Transform[] _masicSpawnPoint;
    [SerializeField,Header("魔法のオブジェクトPrefab")] GameObject _masicObject;
    [SerializeField, Header("オブジェクトがLookonしたターゲットに向かって移動する速度")] float _masicObjectMoveSpeed;
    /// <summary>オブジェクトがLookonしたターゲットに向かって移動する関数を実装</summary>
    event Action _masicAction;
    public Action MasicAction { get { return _masicAction; } set { _masicAction = value; } }

    public float MasicObjectMoveSpeed => _masicObjectMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(MasicAttack());
        }
    }

    IEnumerator MasicAttack()
    {
        for (var i = 0; i < _masicSpawnPoint.Length; i++)
        {
            GameObject go = Instantiate(_masicObject, _masicSpawnPoint[i].position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.5f);
        _masicAction.Invoke();
    }
}
