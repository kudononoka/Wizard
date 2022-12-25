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
        //葉っぱUIの数は１～１０までサイズや位置の調整可能・１１以上だとUIが崩れる可能性がある
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
            //生成した葉っぱUIのSpriteをListに入れていく
            _usebleMPLeaf.Add(sprite);　 //今使用できるMP(葉っぱ)のUIList
            _MPLeaf.Add(sprite);　//生成した全ての葉っぱUIの保管場所
        }
        
    }

    public void Consumption(int amount)
    {
        int n = amount / 2;
        int n2 = amount % 2;
        //使用できるMPの葉っぱUIの最後尾が半分の葉っぱUIの状態だったら
        if (_usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite == _leafHalfSprite)
        {
             //半分の葉っぱUIを輪郭だけの葉っぱUIに変える
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
        //使用できるMPの葉っぱUIの最後尾が半分の葉っぱUIの状態だったら
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
        //Listに入っている葉っぱUIの中で輪郭だけの葉っぱUIの先頭を変数に入れる
        var listSprite = _MPLeaf.Where(x => x.sprite == _leafNoneSprite).First();
        //新たに使用可能のMP葉っぱUIListにいれSpriteを半分の状態の葉っぱUIか普通の葉っぱUIに変える
        _usebleMPLeaf.Add(listSprite);
        _usebleMPLeaf[_usebleMPLeaf.Count - 1].sprite = sprite;
    }
}
