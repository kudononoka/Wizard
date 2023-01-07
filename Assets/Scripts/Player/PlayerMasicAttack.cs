using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMasicAttack : MonoBehaviour
{
    [SerializeField, Header("魔法を生成する場所")] Transform[] _masicSpawnPoint;
    [SerializeField,Header("魔法のオブジェクトPrefab")] GameObject _masicObject;
    [SerializeField, Header("オブジェクトがLookonしたターゲットに向かって移動する速度")] float _masicObjectMoveSpeed;
    /// <summary>オブジェクトがLockonしたターゲットに向かって移動する関数を実装するデリゲート</summary>
    event Action _masicAction;
    /// <summary>オブジェクトがLockonしたターゲットに向かって移動する関数を実装するデリゲートカプセル化</summary>
    public Action MasicAction { get { return _masicAction; } set { _masicAction = value; } }
    /// <summary>オブジェクトがLookonしたターゲットに向かって移動する速度</summary>
    public float MasicObjectMoveSpeed => _masicObjectMoveSpeed;

    [SerializeField, Header("生成されてから動くまでの停止時間")] float _intervalObjectMove = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
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
