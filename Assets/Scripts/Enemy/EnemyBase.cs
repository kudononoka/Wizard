using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>Enemy�̊��N���X�ł� </summary>
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("Starge��̗B���Boss���ǂ���")]public bool _isBoss;
    [SerializeField]protected int _nowHp;
    [SerializeField] int _maxHp;
    PlayerLockon _lockon;
    [SerializeField, Header("��_����")] public GoAttribute _attribute;
    /// <summary>Player�̋ߐڍU������_���[�W���󂯂��ꍇ��Player��MP�񕜗�</summary>
    [SerializeField,Header("�_���[�W���󂯂�����Player��MP�񕜗�")] int _MPRecoveryAmount;
    [SerializeField, Header("Boss��HPSlider")] protected GameObject _bossSlider;
    Slider _hpSlider;
    // Start is called before the first frame update
    private void Awake()
    {
        _nowHp = _maxHp;
        _lockon = FindObjectOfType<PlayerLockon>();
        if (_isBoss)
        {
            _hpSlider = _bossSlider.GetComponent<Slider>();
            _hpSlider.maxValue = _nowHp;
            _hpSlider.minValue = 0;
            _hpSlider.value = _nowHp;
            _bossSlider.SetActive(false);
        }
    }
    void Start()
    {
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

   public void Damage(int damage)
    {
        Debug.Log("damage");
        _nowHp -= damage;
        if(_nowHp < 0)
        {
            Destroy(gameObject);
        }
    }

    public enum GoAttribute
    {
        Fire = 1,
        Ice = 2,
        Wind = 3,
        Thunder = 4,
    }

    public void SliderControlle()
    {
        if (_isBoss)
        {
            if(_nowHp <= 0)
            {
                ChangeSceneManager changeScene = GameObject.Find("SceneManager").GetComponent<ChangeSceneManager>();
                changeScene.ChangeScene("GameClear");
            }
            _hpSlider.value = _nowHp;
        }
    }
}

