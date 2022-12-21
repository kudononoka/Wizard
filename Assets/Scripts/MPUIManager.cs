using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MPUIManager : MonoBehaviour
{
    [SerializeField] GameObject _reafPrefab;
    [SerializeField] Sprite _sprite;
    [SerializeField] Sprite _sprite2;
    [SerializeField] Sprite _sprite1;
    [SerializeField] List<Image> _list = new List<Image>();
    [SerializeField] List<Image> _list2 = new List<Image>();
    PlayerHPMP _playerHPMP;
    GridLayoutGroup _group;
    RectTransform _rectTransform;
    int _reafNum;
    // Start is called before the first frame update
    void Start()
    {
        _playerHPMP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHPMP>();
        _group = GetComponent<GridLayoutGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _reafNum = _playerHPMP.ReafNum;
        _group.constraintCount = _reafNum;
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
            GameObject go =  Instantiate(_reafPrefab, this.transform);
            Image sprite = go.GetComponent<Image>();
            _list.Add(sprite);
            _list2.Add(sprite);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changed(int amount)
    {
        int n = amount / 2;
        int n2 = amount % 2;
        
        if (transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite == _sprite)
        {
            _list[_list.Count - 1].sprite = _sprite2;
            //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite2;
            _list.RemoveAt(_list.Count - 1);
            amount--;
            n = amount / 2;
            n2 = amount % 2;

            for (var i = 1; i <= n; i++)
            {
                _list[_list.Count - 1].sprite = _sprite2;
                //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite2;
                _list.RemoveAt(_list.Count - 1);
            }
            if (n2 == 1)
            {
                _list[_list.Count - 1].sprite = _sprite;
                transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite;
            }
        }
        else
        {
            for (var i = 1; i <= n ; i++)
            {
                _list[_list.Count - 1].sprite = _sprite2;
                //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite2;
                _list.RemoveAt(_list.Count - 1);
            }
            if (n2 == 1)
            {
                _list[_list.Count - 1].sprite = _sprite;
                //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite;
            }
        }
        
    }
    public void Recovery(int amount)
    {
        int n = amount / 2;
        int n2 = amount % 2;
       
        if (_list.Count != 0 && transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite == _sprite)
        {
            _list[_list.Count - 1].sprite = _sprite1;
            //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite1;
            amount--;
            n = amount / 2;
            n2 = amount % 2;
            if (_list.Count < 10)
            {
                for (var i = 1; i <= n; i++)
                {
                    var listSprite = _list2.Where(x => x.sprite == _sprite2).First();
                    _list.Add(listSprite);
                    _list[_list.Count - 1].sprite = _sprite1;
                    //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite1;
                }
                if (n2 == 1)
                {
                    var listSprite = _list2.Where(x => x.sprite == _sprite2).First();
                    _list.Add(listSprite);
                    _list[_list.Count - 1].sprite = _sprite;
                    //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite;
                }
            }
        }
        
        else
        {
            for (var i = 1; i <= n && _list.Count < 10; i++)
            {
                var listSprite = _list2.Where(x => x.sprite == _sprite2).First();
                _list.Add(listSprite);
                _list[_list.Count - 1].sprite = _sprite1;
                //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite1;
            }
            if (n2 == 1 && _list.Count < 10)
            {
                var listSprite = _list2.Where(x => x.sprite == _sprite2).First();
                _list.Add(listSprite);
                _list[_list.Count - 1].sprite = _sprite;
                //transform.GetChild(_list.Count - 1).GetComponent<Image>().sprite = _sprite;
            }

        }
    }
}
