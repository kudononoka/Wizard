using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockonUIObjectController : MonoBehaviour
{
    /// <summary>mainCamera�̈ʒu</summary>
    Transform _mcTransform;
    RectTransform _rectTransform;
    PlayerLockon _playerLockon;
    /// <summary>MainCamera���烍�b�N�I�����Ă���EnemyGO�܂ł̃x�N�g����ۊǂ��邽�߂̕ϐ�</summary>
    Vector3 _dir;
    /// <summary>MainCamera���烍�b�N�I�����Ă���EnemyGO�܂ł̃x�N�g����ۊǂ��邽�߂̕ϐ�</summary>
    [SerializeField, Header("�J�����Ƃ��̃I�u�W�F�N�g(LockonUICanvas)�̋��������p"), Tooltip("�����Ƃ��Ďg������0�`1�ɁA1�ɋ߂Â��ɂꂱ�̃I�u�W�F�N�g���J�������痣��Ă���"), Range(0, 1f)] float _lockonUIdistance;
    // Start is called before the first frame update
    void Start()
    {
        _mcTransform = Camera.main.GetComponent<Transform>();
        _playerLockon = FindObjectOfType<PlayerLockon>();
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_playerLockon.IsLockon)
        {
            //MainCamera���烍�b�N�I�����Ă���EnemyGO�̌������擾
            if (_playerLockon.TargetPos != null)
            {
                _dir = _playerLockon.TargetPos.position - _mcTransform.position;
            }

            //���̃Q�[���I�u�W�F�N�g��Canvas���J���������Ɍ�����
            _rectTransform.forward = -_dir;

            //_dir�x�N�g������ɂ���go��u��
            //�V�����x�N�g��vectorEndpoint�̏I�_������go��u���\��̏ꏊ�Ƃ��A�I�_��_dir�x�N�g���̊����Œ�������
            Vector3 vectorEndpoint = _dir * _lockonUIdistance;

            //MainCamera�̃��[���h���W�̃x�N�g����MainCamera���炱��go��u���\��̏ꏊ�܂ł̃x�N�g���𑫂���
            //����go��u���\��̏ꏊ�̃��[���h���W�����߁Atransform�ɑ��
            _rectTransform.position = _mcTransform.position + vectorEndpoint;
            
        }
        else
        {
            //���b�N�I�����Ă��Ȃ����͌����Ȃ��悤�ɃJ�����̐^���ɒu��
            Vector3 pos = _mcTransform.position;
            pos.y -= 1f;
            _rectTransform.position = pos;
        }
    }
}
