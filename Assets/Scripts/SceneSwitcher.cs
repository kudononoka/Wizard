using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("移動先のシーン"), SerializeField] string _sceneName;
    [Header("移動先"), SerializeField] Transform _arrivalPoint;

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
