using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    private string _startPointName = "";
    private Vector3 _startPlayerDir = Vector3.zero;

    public string StartPointName { get => _startPointName; set => _startPointName = value; }
    public Vector3 StartPlayerDir { get => _startPlayerDir; set => _startPlayerDir = value; }
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            SceneManager.sceneLoaded += SceneLoad;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void SceneLoad(Scene scene, LoadSceneMode mode)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (_startPointName != "")
        {
            Vector3 point = GameObject.Find(_startPointName).GetComponent<Transform>().position;

            if (player)
            {
                player.transform.position = point;
            }
            else
            {
                Debug.LogError("Player ��������܂���B");
            }
        }

        if (player)
        {
            player.transform.eulerAngles = _startPlayerDir;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>���݂̃Q�[���̏�ԊǗ��p��enum</summary>
    public enum GameState
    {
        Title = 0,
        isGame = 1,
        GameOver = 2,
        GameClear = 3,
        Result = 4,
    }
    
}
