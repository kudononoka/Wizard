using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class PlayerLockon : MonoBehaviour
{
    /// <summary>シーン内のEnemyObject</summary>
    [SerializeField]List<GameObject> _goEnemise = new List<GameObject>();
    int _index;
    [Tooltip("ロックオンした時の対象のゲームオブジェクト")]Transform _targetPos; public Transform TargetPos{get { return _targetPos; }set { _targetPos = value; }}
    [SerializeField] CinemachineTargetGroup _group;
    [SerializeField, Tooltip("TargetGroupのtargetのweight")] float _weight;
    [SerializeField, Tooltip("TargetGroupのtargetのradius")] float _radius;
    [SerializeField, Header("ロックオン中のVC")] CinemachineVirtualCamera _virtualCamera;
    [SerializeField, Header("普段使う仮想カメラ(FreeLook)")] CinemachineFreeLook _freelookCmera;
    /// <summary>Trueの時　ロックオン中</summary>
    bool _isLockon = false;
    /// <summary>Trueの時　ロックオン中</summary>
    public bool IsLockon => _isLockon;
    // Start is called before the first frame update
    void Start()
    {
        _isLockon = false;
        _freelookCmera.MoveToTopOfPrioritySubqueue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Lockon"))
        {
            _isLockon = !_isLockon;
            if (_isLockon)
            {
                _index = 0;
                AddListEnemy();
                _virtualCamera.MoveToTopOfPrioritySubqueue();
                _targetPos = _goEnemise[_index].GetComponent<Transform>();
                _group.m_Targets[1].target = _targetPos;
            }
            else
            {
                _freelookCmera.MoveToTopOfPrioritySubqueue();
                _goEnemise.Clear();
            }
        }
        if (Input.GetButtonDown("Lockon") && _isLockon)
        { 
            _targetPos = _goEnemise[_index].GetComponent<Transform>(); 
            _group.m_Targets[1].target = _targetPos;
            _index++;
            if (_index >= _goEnemise.Count)
            {
                _index = 0;
            }
        }

        if(_isLockon)
        {
            if (_goEnemise.Count == 0)
            {
                _freelookCmera.MoveToTopOfPrioritySubqueue();
                _isLockon = !_isLockon;
            }
            else
            {
                if (_targetPos == null)
                {
                    _goEnemise.RemoveAll(enemy => enemy == null);
                    if (_goEnemise.Count > 0)
                    {
                        _index = _goEnemise.Count - 1;
                        _targetPos = _goEnemise[_index].GetComponent<Transform>();
                    }
                }
                else
                {
                    Vector3 pos = _targetPos.position;
                    pos.y = 0;
                    transform.rotation = Quaternion.LookRotation(pos);
                }
            }
        }
    }

    public void AddListEnemy()
    {
        var goEnemise = GameObject.FindGameObjectsWithTag("Enemy");
        _goEnemise = goEnemise.Where(enemy => enemy.GetComponent<Slime>().state == Slime.State.IsBattle).OrderBy(enemy => Vector3.Distance(this.transform.position, enemy.transform.position)).ToList();
    }
}
