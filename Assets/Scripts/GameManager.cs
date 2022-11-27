using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance)
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

    void SceneLoad(Scene scene,LoadSceneMode mode)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        //if (this.PointNameOnSceneLoaded != "")
        //{
        //    var point = GameObject.Find(this.PointNameOnSceneLoaded);

        //    if (player)
        //    {
        //        player.transform.position = point.transform.position;
        //    }
        //    else
        //    {
        //        Debug.LogError("Player Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÅB");
        //    }
        //}
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
