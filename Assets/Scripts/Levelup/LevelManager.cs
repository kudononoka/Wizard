using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour
{
    
    /// <summary>�eLevel��Player�̃p�����[�^�[�������Ă���Dictinary�E�L�[��LevelNumber�Ƃ��L�[���ĂԂ����ő��̃p�����[�^�[���ς���悤�ɂ���</summary>
    Dictionary<int, PlayerStateLevel> _levelDate = new Dictionary<int, PlayerStateLevel>();

    [SerializeField, Header("CSV�`����LevelUpTable")] string _fileName;
    private void Awake()
    {

        string filePath = Application.persistentDataPath + "/" + _fileName;

        using (StreamReader fp = new StreamReader(filePath))
        {
            //��s�ڂ͗񖼂Ȃ̂ŕۊǂ�����΂�
            fp.ReadLine();

            while (true)
            {
                string line = fp.ReadLine();
                //line�ɉ��������Ă��Ȃ�������I������
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                //CSV�`���̓J���}��؂�ł̃f�[�^�Ȃ̂ŁA�J���}�ŕ������Ĕz��ɓ����
                string[] parts = line.Split(',');
                //_levelDate�̃L�[��LevelNumber������邽�߂��炩���ߕϐ��ɕۊǂ��Ă���
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