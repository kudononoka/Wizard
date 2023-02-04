using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour
{
    
    /// <summary>各LevelのPlayerのパラメーターが入っているDictinary・キーをLevelNumberとしキーを呼ぶだけで他のパラメーターも変えるようにする</summary>
    Dictionary<int, PlayerStateLevel> _levelDate = new Dictionary<int, PlayerStateLevel>();

    [SerializeField, Header("CSV形式のLevelUpTable")] string _fileName;
    private void Awake()
    {

        string filePath = Application.persistentDataPath + "/" + _fileName;

        using (StreamReader fp = new StreamReader(filePath))
        {
            //一行目は列名なので保管せず飛ばす
            fp.ReadLine();

            while (true)
            {
                string line = fp.ReadLine();
                //lineに何も入っていなかったら終了する
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                //CSV形式はカンマ区切りでのデータなので、カンマで分割して配列に入れる
                string[] parts = line.Split(',');
                //_levelDateのキーにLevelNumberをいれるためあらかじめ変数に保管しておく
                int level = int.Parse(parts[0]);
                PlayerStateLevel state = new PlayerStateLevel(level, int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
                _levelDate.Add(level, state);

            }
        }
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }
    public PlayerStateLevel LevelUp(int level)
    {
        return _levelDate[level];
    }
}
public struct PlayerStateLevel
{
    private int level; public int Level { get { return level; } }
    private int maxHp;
    private int attackPower;
    private int defensePower;
    private int levelUpPoint; public int LevelUpPoint { get { return levelUpPoint; } }

    public PlayerStateLevel(int level, int maxhp, int attackPower, int defensePower, int levelUpPoint)
    {
        this.level = level;
        this.maxHp = maxhp;
        this.attackPower = attackPower;
        this.defensePower = defensePower;
        this.levelUpPoint = levelUpPoint;
    }
}