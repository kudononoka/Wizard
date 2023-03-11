using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MPUIManager : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////
    //////////////////////////MP�͗t���ςŕ\�����Ă��܂�//////////////////////////
    //////////////////////////////////////////////////////////////////////////////

    //�t���ψꖇ  ���^����MP:2�@������MP:1 �֊s�����\������Ă����Ԃ�MP:0
    [SerializeField, Tooltip("���^���̏�Ԃ̗t����Sprite�̃Q�[���I�u�W�F�N�gPrefab�ł�")] GameObject _leafPrefab;
    [SerializeField, Tooltip("�����̏�Ԃ̗t����Sprite")] Sprite _leafHalfSprite;
    [SerializeField, Tooltip("�Ȃ���Ȃ���Ԃ̗t����Sprite(�֊s����)")] Sprite _leafNoneSprite;
    [SerializeField, Tooltip("���^���̏�Ԃ̗t����Sprite")] Sprite _leafNormalSprite;

    ///<summary>����List�͗t���ψꖇ��MP��0�ɂȂ�����List����O���܂�</summary>
    [SerializeField, Tooltip("���g�p�ł���MP(�t����)��UIList")] List<Image> _usebleMPLeaf = new List<Image>();
    ///<summary>����List�͗t���ψꖇ��MP��0�ɂȂ����Ƃ��Ă�List�ɂ��葱���܂�</summary>
    [SerializeField, Tooltip("���������S�Ă̗t����UI�̕ۊǏꏊ")] List<Image> _MPLeaf = new List<Image>();
    [SerializeField]PlayerHPMP _playerHPMP;
    GridLayoutGroup _group;
    RectTransform _rectTransform;
    int _reafNum;
    void Start()
    {
        _group = GetComponent<GridLayoutGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _reafNum = _playerHPMP.ReafNum;
        _group.constraintCount = _reafNum;
        //�t����UI�̐��͂P�`�P�O�܂ŃT�C�Y��ʒu�̒����\�E�P�P�ȏゾ��UI�������\��������
        if(_reafNum > 7)
        {
            int n = _reafNum - 7;
            for(int i = 0; i < n; i++)
            {
                _rectTransform.localScale -= new Vector3(0.1f, 0.1f, 0);
                Vector3 pos = _rectTransform.position;
                pos.y += 5;
                _rectTransform.position = pos;
            }
        }
        for(var i = 0; i < _reafNum; i++)
        {
            GameObject go =  Instantiate(_leafPrefab, this.transform);
            Image sprite = go.GetComponent<Image>();
            //���������t����UI��Sprite��List�ɓ���Ă���
            _usebleMPLeaf.Add(sprite);�@ 
            _MPLeaf.Add(sprite);�@
        }
        
    }
    /// <summary>MP����Ɋւ��Ă�Sprite�Ǘ��֐�</summary>
    /// _usebleMPLeaf��List�͗t���ψꖇ��MP��0�ɂȂ�����List����O��
    /// <param name="amount">������</param>
    public void Consumption(int amount)
    {
        //�ꖇ�ɂ�MP2�Ȃ̂�amount���Q�ŏ��Z
        int n = amount / 2;
        int n2 = amount % 2;
        //�g�p�ł���MP�̗t����UI�̍Ō���������̗t����UI�̏�Ԃ�������
        if (_usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite == _leafHalfSprite)
        {
            //�����̗t����UI��֊s�����̗t����UI�ɕς���
            _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = _leafNoneSprite;
            _usebleMPLeaf.RemoveAt(_usebleMPLeaf.Count - 1);
            amount--;
            n = amount / 2;
            n2 = amount % 2;

            MPConsumptionSpriteChange(n, n2);
        }
        else
        {
            MPConsumptionSpriteChange(n, n2);
        }
        
    }
    public void Recovery(int amount)
    {
        int n = amount / 2;
        int n2 = amount % 2;
        //�g�p�ł���MP�̗t����UI�̍Ō���������̗t����UI�̏�Ԃ�������
        if (_usebleMPLeaf.Count != 0 && _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite == _leafHalfSprite)
        {
            _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = _leafNormalSprite;
            amount--;
            n = amount / 2;
            n2 = amount % 2;
            MPRecoverySpriteChange(n, n2);
        }
        else
        {
            MPRecoverySpriteChange(n, n2);
        }
    }
    public void MPConsumptionSpriteChange(int n, int n2)
    {
        for (var i = 1; i <= n; i++)
        {
            _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = _leafNoneSprite;
            _usebleMPLeaf.RemoveAt(_usebleMPLeaf.Count - 1);
        }
        if (n2 == 1)
        {
            _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = _leafHalfSprite;
        }
    }

    public void MPRecoverySpriteChange(int n, int n2)
    {
        for (var i = 1; i <= n && _usebleMPLeaf.Count < 10; i++)
        {
            //List�ɓ����Ă���t����UI�̒��ŗ֊s�����̗t����UI�̐擪��ϐ��ɓ����
            var listSprite = _MPLeaf.Where(x => x.sprite == _leafNoneSprite).First();
            //�V���Ɏg�p�\��MP�t����UIList�ɂ���Sprite�𔼕��̏�Ԃ̗t����UI�����ʂ̗t����UI�ɕς���
            _usebleMPLeaf.Add(listSprite);
            _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = _leafNormalSprite;
        }
        if (n2 == 1 && _usebleMPLeaf.Count < 10)
        {
            var listSprite = _MPLeaf.Where(x => x.sprite == _leafNoneSprite).First();
            _usebleMPLeaf.Add(listSprite);
            _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = _leafHalfSprite;
        }
    }
}
