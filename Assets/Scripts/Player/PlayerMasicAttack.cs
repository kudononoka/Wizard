using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMasicAttack : MonoBehaviour
{
    [SerializeField, Header("���@�𐶐�����ꏊ")] Transform[] _masicSpawnPoint;
    [SerializeField,Header("���@�̃I�u�W�F�N�gPrefab")] GameObject _masicObject;
    [SerializeField, Header("�I�u�W�F�N�g��Lookon�����^�[�Q�b�g�Ɍ������Ĉړ����鑬�x")] float _masicObjectMoveSpeed;
    /// <summary>�I�u�W�F�N�g��Lockon�����^�[�Q�b�g�Ɍ������Ĉړ�����֐�����������f���Q�[�g</summary>
    event Action _masicAction;
    /// <summary>�I�u�W�F�N�g��Lockon�����^�[�Q�b�g�Ɍ������Ĉړ�����֐�����������f���Q�[�g�J�v�Z����</summary>
    public Action MasicAction { get { return _masicAction; } set { _masicAction = value; } }
    /// <summary>�I�u�W�F�N�g��Lookon�����^�[�Q�b�g�Ɍ������Ĉړ����鑬�x</summary>
    public float MasicObjectMoveSpeed => _masicObjectMoveSpeed;

    [SerializeField, Header("��������Ă��瓮���܂ł̒�~����")] float _intervalObjectMove = 0.5f;

    PlayerLockon _lockon;
    /// <summary>�����@�I�u�W�F�N�g�����鎞������܂Ŏ��̖��@�I�u�W�F�N�g���o���Ȃ�t���߂�List�ECount��0�ɂȂ����琶���ł���悤�ɂ���</summary>
    List<GameObject> _nowMasicGOActive = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _lockon = FindObjectOfType<PlayerLockon>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_nowMasicGOActive.Count > 0)
        {
            _nowMasicGOActive.RemoveAll(go => go == null);
        }
        if(Input.GetKeyDown(KeyCode.Z) && _lockon.IsLockon && _nowMasicGOActive.Count == 0)
        {
            StartCoroutine(MasicAttack());
        }
    }

    IEnumerator MasicAttack()
    {
        for (var i = 0; i < _masicSpawnPoint.Length; i++)
        {
            GameObject go = Instantiate(_masicObject, _masicSpawnPoint[i].position, Quaternion.identity);
            _nowMasicGOActive.Add(go);
        }
        yield return new WaitForSeconds(0.5f);
        _masicAction.Invoke();
    }
}
