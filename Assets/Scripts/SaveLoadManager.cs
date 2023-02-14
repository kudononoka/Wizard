using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] SaveData _data; 
    string _filePath;
    [SerializeField,Header("SaveData��ۊǂ���ӂ�����")]string _fileName;
    private void Awake()
    {
        //_data = go.GetComponent<SaveData>();
        //Debug.Log(Application.dataPath);
        //_filePath = Application.dataPath + "/" + _fileName;

        ////���̖��O�̃t�@�C���Ȃ����V�������̖��O�Ńt�@�C����V�K�쐬
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

        //���̖��O�̃t�@�C���Ȃ����V�������̖��O�Ńt�@�C����V�K�쐬
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
        //�f�[�^��json�ɕϊ�����
        string json = JsonUtility.ToJson(_data);
        Debug.Log(json);
        //�t�@�C���̏�������
        using (StreamWriter wrter = new StreamWriter(_filePath, false))
        {
            //�����w�肵���t�@�C���ɏ�������
            wrter.WriteLine(json);
            //�t�@�C�������
            wrter.Close();
        }
    }

    void Load()
    {
        if (File.Exists(_filePath))
        {
            //�t�@�C���̓ǂݍ���
            using (StreamReader sr = new StreamReader(_filePath))
            {
                //�t�@�C���̓��e��S�ēǂݍ���
                string json = sr.ReadToEnd();
                Debug.Log(json);
                sr.Close();
                JsonUtility.FromJsonOverwrite(json, _data);
            }
        }
    }
}
