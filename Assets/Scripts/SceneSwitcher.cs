using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("移動先のシーン"), SerializeField] string _sceneName;
    [Header("移動先のオブジェクト"), SerializeField] string _arrivalPoint;

    void SwitchScene(string sceneName, string arrivalPoint,Vector3 dir)
    {
        GameManager.Instance.StartPointName = arrivalPoint;
        GameManager.Instance.StartPlayerDir = dir;
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SwitchScene(_sceneName, _arrivalPoint,other.gameObject.transform.eulerAngles);
        }
    }

    private void NormalSceneMove()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
