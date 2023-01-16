using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("SkillButtonを表示するUIPanel")] GameObject _skillPanel;
    [SerializeField, Header("AttributeButtonを表示するUIPanel")] GameObject _attributePanel;
    RectTransform _skillPanelRectTrans;
    RectTransform _attributePanelRectTrans;
    [SerializeField, Header("Panelを表示するときのPanelサイズ")]Vector3 _panelOnScale;
    [SerializeField, Header("Panelを非表示にするときのPanelサイズ")] Vector3 _panelOffScale;
    List<Button> _skillButtons = new List<Button>();
    List<Button> _attributeButtons = new List<Button>();
    
    // Start is called before the first frame update
    void Start()
    {
        _skillPanelRectTrans = ListAdd(_skillButtons, _skillPanel, _skillPanelRectTrans, _panelOffScale);
        _attributePanelRectTrans = ListAdd(_attributeButtons, _attributePanel, _attributePanelRectTrans, _panelOffScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            Debug.Log("a");
            ButtonInteractable(_skillButtons, _skillPanelRectTrans, _panelOnScale, true);
        }
        else
        {
            ButtonInteractable(_skillButtons, _skillPanelRectTrans, _panelOffScale, true);
        }

        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("a");
            ButtonInteractable(_attributeButtons, _attributePanelRectTrans, _panelOnScale, true);
        }
        else
        {
            ButtonInteractable(_attributeButtons, _attributePanelRectTrans, _panelOffScale, true);
        }
    }

    void ButtonInteractable(List<Button> buttons, RectTransform rect, Vector3 panelScale,  bool trueORfalse)
    {
        rect.localScale = panelScale;
        for(var i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = trueORfalse;
        }
    }

    RectTransform ListAdd(List<Button> buttons, GameObject panel, RectTransform rect, Vector3 panelScale)
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
