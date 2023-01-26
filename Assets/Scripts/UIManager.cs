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
        _skillPanelRectTrans = ListAddAndPanelScaleControll(_skillButtons, _skillPanel, _skillPanelRectTrans, _panelOffScale);
        _attributePanelRectTrans = ListAddAndPanelScaleControll(_attributeButtons, _attributePanel, _attributePanelRectTrans, _panelOffScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            ButtonInteractable(_skillButtons, _skillPanelRectTrans, _panelOnScale, true);
        }
        else
        {
            ButtonInteractable(_skillButtons, _skillPanelRectTrans, _panelOffScale, true);
        }

        if (Input.GetKey(KeyCode.C))
        {
            ButtonInteractable(_attributeButtons, _attributePanelRectTrans, _panelOnScale, true);
        }
        else
        {
            ButtonInteractable(_attributeButtons, _attributePanelRectTrans, _panelOffScale, true);
        }
    }
    /// <summary>
    /// ButtonコンポーネントのInteractable
    /// </summary>
    /// <param name="buttons">Panelゲームオブジェクトの子オブジェクトについているButtonの配列</param>
    /// <param name="rect">RectTransformコンポーネント</param>
    /// <param name="panelScale">PanelのScaleを変えるための変数</param>
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
