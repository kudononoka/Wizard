using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("SkillButton��\������UIPanel")] GameObject _skillPanel;
    [SerializeField, Header("AttributeButton��\������UIPanel")] GameObject _attributePanel;
    RectTransform _skillPanelRectTrans;
    RectTransform _attributePanelRectTrans;
    [SerializeField, Header("Panel��\������Ƃ���Panel�T�C�Y")]Vector3 _panelOnScale;
    [SerializeField, Header("Panel���\���ɂ���Ƃ���Panel�T�C�Y")] Vector3 _panelOffScale;
    List<Button> _skillButtons = new List<Button>();
    List<Button> _attributeButtons = new List<Button>();
    [SerializeField] Button[] _selectButton;
    [SerializeField] Sprite[] _attributeImage;
    [SerializeField] GameObject _playerattribute;
    // Start is called before the first frame update
    void Start()
    {
        //_skillPanelRectTrans = ListAddAndPanelScaleControll(_skillButtons, _skillPanel, _skillPanelRectTrans, _panelOffScale);
        _attributePanelRectTrans = ListAddAndPanelScaleControll(_attributeButtons, _attributePanel, _attributePanelRectTrans, _panelOffScale);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.C))
        //{
        //    ButtonInteractable(_skillButtons, _skillPanelRectTrans, _panelOnScale, true);
        //}
        //else
        //{
        //    ButtonInteractable(_skillButtons, _skillPanelRectTrans, _panelOffScale, true);
        //}

        if (Input.GetButton("UIActive"))
        {
            ButtonInteractable(_attributeButtons, _attributePanelRectTrans, _panelOnScale, true);
            Sprite image = _playerattribute.GetComponent<Image>().sprite;
            if(Input.GetAxisRaw("MasicChangeHorizontal") == 1)
            {
                _selectButton[2].onClick.Invoke();
                image = _attributeImage[2];
                Debug.Log("��");
            }
            else if(Input.GetAxisRaw("MasicChangeHorizontal") == -1)
            {
                _selectButton[3].onClick.Invoke();
                image = _attributeImage[3];
                Debug.Log("��");
            }
            else if(Input.GetAxisRaw("MasicChangeVertical") == 1)
            {
                _selectButton[0].onClick.Invoke();
                image = _attributeImage[0];
                Debug.Log("��");
            }
            else if (Input.GetAxisRaw("MasicChangeVertical") == -1)
            {
                Debug.Log("�X");
                _selectButton[1].onClick.Invoke();
                image = _attributeImage[1];
            }
            _playerattribute.GetComponent<Image>().sprite = image;
        }
        else
        {
            ButtonInteractable(_attributeButtons, _attributePanelRectTrans, _panelOffScale, true);
        }
    }
    /// <summary>
    /// Button�R���|�[�l���g��Interactable
    /// </summary>
    /// <param name="buttons">Panel�Q�[���I�u�W�F�N�g�̎q�I�u�W�F�N�g�ɂ��Ă���Button�̔z��</param>
    /// <param name="rect">RectTransform�R���|�[�l���g</param>
    /// <param name="panelScale">Panel��Scale��ς��邽�߂̕ϐ�</param>
    /// <param name="trueORfalse"></param>
    void ButtonInteractable(List<Button> buttons, RectTransform rect, Vector3 panelScale,  bool trueORfalse)
    {
        rect.localScale = panelScale;
        for(var i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = trueORfalse;
        }
    }

    RectTransform ListAddAndPanelScaleControll(List<Button> buttons, GameObject panel, RectTransform rect, Vector3 panelScale)
    {
        rect = panel.GetComponent<RectTransform>();
        rect.localScale = panelScale;
        for (var i = 0; i < 4; i++)
        {
            buttons.Add(panel.transform.GetChild(i).gameObject.GetComponent<Button>());
        }

        return rect;
    }

}
