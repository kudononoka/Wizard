using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] SaveData _data; 
    string _filePath;
    [SerializeField,Header("SaveDataを保管するふぁいる")]string _fileName;
    private void Awake()
    {
        //_data = go.GetComponent<SaveData>();
        //Debug.Log(Application.dataPath);
        //_filePath = Application.dataPath + "/" + _fileName;

        ////この名前のファイがない時新しくこの名前でファイルを新規作成
        //if (!File.Exists(_filePath))
        //{
        //    Save(_data);
        //}

        //_data = Load();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.dataPath);
        Debug.Log(Application.persistentDataPath);
        _filePath = $"{Application.persistentDataPath}/{_fileName}.json";

        //この名前のファイがない時新しくこの名前でファイルを新規作成
        //if (!File.Exists(_filePath))
        //{
        //    Save();
        //}
    }

    public void SaveAction()
    {
        _data.Save();
        Save();
    }

    public void LoadAction()
    {
        Load();
        _data.Load();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Save()
    {
        //データをjsonに変換して
        string json = JsonUtility.ToJson(_data);
        Debug.Log(json);
        //ファイルの書き込み
        using (StreamWriter wrter = new StreamWriter(_filePath, false))
        {
            //情報を指定したファイルに書き込む
            wrter.WriteLine(json);
            //ファイルを閉じる
            wrter.Close();
        }
    }

    void Load()
    {
        if (File.Exists(_filePath))
        {
            //ファイルの読み込み
            using (StreamReader sr = new StreamReader(_filePath))
            {
                //ファイルの内容を全て読み込む
                string json = sr.ReadToEnd();
                Debug.Log(json);
                sr.Close();
                JsonUtility.FromJsonOverwrite(json, _data);
            }
        }
    }
}
