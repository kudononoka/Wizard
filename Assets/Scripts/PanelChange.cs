using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    [SerializeField] GameObject[] _panel;
    // Start is called before the first frame update
    void Start()
    {
        _panel[0].SetActive(true);
        _panel[1].SetActive(false);
        _panel[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelChangeSetActive(int num)
    {
        for(var i = 0; i < _panel.Length; i++)
        {
            if(i == num)
            {
                _panel[i].SetActive(true);
            }
            else
            {
                _panel[i].SetActive(false);
            }
        }
    }
}
