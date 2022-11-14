using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("�ړ���̃V�[��"), SerializeField] string _sceneName;
    [Header("�ړ���"), SerializeField] Transform _arrivalPoint;

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
