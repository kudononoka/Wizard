using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData : MonoBehaviour
{
    [SerializeField] Vector3 _playerTra;
    [SerializeField] string _nowSceneName;

    private void Awake()
    {
        _playerTra = transform.position;
    }
    public void Save()
    {
        _playerTra = transform.position;
    }
    public void Load()
    {
        transform.position = _playerTra;
    }
}

//public struct SavePlayer
//{
//    private Transform _playerTra;
//    private string _name;

//    public SavePlayer(Transform t, string name)
//    { 
//         this._playerTra=t;
//        this._name = name;
//    }
//}

