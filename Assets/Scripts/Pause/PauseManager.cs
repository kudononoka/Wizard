using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    /// <summary>true‚ÌŽž‚ÍˆêŽž’âŽ~</summary>
    bool isPuause = false;
    
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            PauseResume();
            Debug.Log("ˆêŽž’âŽ~");
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
            }
            else
            {
                i?.Resume();
            }
        }
    }
}
