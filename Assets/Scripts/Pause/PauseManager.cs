using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    /// <summary>true�̎��͈ꎞ��~</summary>
    bool isPuause = false;
    /// <summary>�ꎞ��~���ɕ\������Canvas</summary>
    [SerializeField] GameObject _pauseCanvas;

    private void Start()
    {
       
    }
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            PauseResume();
            Debug.Log("�ꎞ��~");
        }
    }

    void PauseResume()
    {
        isPuause = !isPuause;

        GameObject[] go = FindObjectsOfType<GameObject>();

        foreach(GameObject o in go)
        {
            InterfacePause i = o.GetComponent<InterfacePause>();
            if(isPuause)
            {
                i?.Pause();
                _pauseCanvas.SetActive(true);
            }
            else
            {
                i?.Resume();
                _pauseCanvas.SetActive(false);
            }
        }
    }
}
