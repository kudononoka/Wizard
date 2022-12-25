using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MPUIManager : MonoBehaviour
{
    [SerializeField] GameObject _leafPrefab;
    [SerializeField] Sprite _leafHalfSprite;
    [SerializeField] Sprite _leafNoneSprite;
    [SerializeField] Sprite _leafNormalSprite;
    [SerializeField] List<Image> _usebleMPLeaf = new List<Image>();
    [SerializeField] List<Image> _MPLeaf = new List<Image>();
    PlayerHPMP _playerHPMP;
    GridLayoutGroup _group;
    RectTransform _rectTransform;
    int _reafNum;
    void Start()
    {
        _playerHPMP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHPMP>();
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
            _usebleMPLeaf.Add(sprite);�@ //���g�p�ł���MP(�t����)��UIList
            _MPLeaf.Add(sprite);�@//���������S�Ă̗t����UI�̕ۊǏꏊ
        }
        
    }

    public void Consumption(int amount)
    {
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
            if (_usebleMPLeaf.Count < 10)
            {
                for (var i = 1; i <= n; i++)
                {
                    MPRecoverySpriteChange(_leafNormalSprite);
                }
                if (n2 == 1)
                {
                    MPRecoverySpriteChange(_leafHalfSprite);
                }
            }
        }
        else
        {
            for (var i = 1; i <= n && _usebleMPLeaf.Count < 10; i++)
            {
                MPRecoverySpriteChange(_leafNormalSprite);
            }
            if (n2 == 1 && _usebleMPLeaf.Count < 10)
            {
                MPRecoverySpriteChange(_leafHalfSprite);
            }

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

    public void MPRecoverySpriteChange(Sprite sprite)
    {
        //List�ɓ����Ă���t����UI�̒��ŗ֊s�����̗t����UI�̐擪��ϐ��ɓ����
        var listSprite = _MPLeaf.Where(x => x.sprite == _leafNoneSprite).First();
        //�V���Ɏg�p�\��MP�t����UIList�ɂ���Sprite�𔼕��̏�Ԃ̗t����UI�����ʂ̗t����UI�ɕς���
        _usebleMPLeaf.Add(listSprite);
        _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = sprite;
    }
}
