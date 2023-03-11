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
            //ChangeSceneManager.sceneLoaded += SceneLoad;
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
                Debug.LogError("Player Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÅB");
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

    [Flags]
    /// <summary>åªç›ÇÃÉQÅ[ÉÄÇÃèÛë‘ä«óùópÇÃenum</summary>
    public enum GameState
    {
        Title = 1 << 0,
        isGame = 1 << 1,
        isButtle = 1 << 2,
        GameOver = 1 << 3,
        GameClear = 1 << 4,
        Result = 1 << 5,
    }
    
}
