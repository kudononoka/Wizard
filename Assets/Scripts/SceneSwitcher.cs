using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("�ړ���̃V�[��"), SerializeField] string _sceneName;
    [Header("�ړ���̃I�u�W�F�N�g"), SerializeField] string _arrivalPoint;

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
}
