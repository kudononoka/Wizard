using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] Text _levelUI;
    PlayerStateLevel _playerState = default;
    int _level = 1;
    int _point;
    // Start is called before the first frame update
    void Start()
    {
        _level = 1;
        //Å‰Level‚P‚ð“ü‚ê‚Ä‚¨‚­
        _playerState = levelManager.LevelUp(_level);
        _levelUI.text = _playerState.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_point + " " + _playerState.LevelUpPoint);
        if(_point > _playerState.LevelUpPoint)
        {
            _level++;
            _playerState = levelManager.LevelUp(_level);
            _point = 0;
            _levelUI.text = _playerState.Level.ToString();
        }
    }

    public void PointUp(int point)
    {
        _point += point;
    }

}
