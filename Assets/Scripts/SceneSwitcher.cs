using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("ˆÚ“®æ‚ÌƒV[ƒ“"), SerializeField] string _sceneName;
    [Header("ˆÚ“®æ"), SerializeField] Transform _arrivalPoint;

    void SwitchScene(string sceneName, Transform arrivalPoint)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

        }
    }
}
