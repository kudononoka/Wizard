using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class PlayerLockon : MonoBehaviour
{
    List<GameObject> _goEnemise = new List<GameObject>();
    int _index;
    [Tooltip("ロックオンした時の対象のゲームオブジェクト")]GameObject _target;
    [SerializeField] CinemachineTargetGroup _group;
    [SerializeField, Tooltip("TargetGroupのtargetのweight")] float _weight;
    [SerializeField, Tooltip("TargetGroupのtargetのradius")] float _radius;
    [SerializeField, Header("ロックオン中のVC")] CinemachineVirtualCamera _virtualCamera;
    [SerializeField, Header("普段使う仮想カメラ(FreeLook)")] CinemachineFreeLook _freelookCmera;
    /// <summary>Trueの時　ロックオン中</summary>
    bool _isLookon = false;
    // Start is called before the first frame update
    void Start()
    {
        AddListEnemy();
        _isLookon = false;
        _freelookCmera.MoveToTopOfPrioritySubqueue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("ロックオン");
            _isLookon = !_isLookon;
            if (_isLookon)
            {
                _virtualCamera.MoveToTopOfPrioritySubqueue();
            }
            else
            {
                _freelookCmera.MoveToTopOfPrioritySubqueue();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isLookon)
        {
            _target = _goEnemise[_index];
            _group.m_Targets[1].target = _target.GetComponent<Transform>();

            _index++;

            if (_index >= _goEnemise.Count)
            {
                _index = 0;
            }
            Debug.Log("ロックオン");
        }
    }

    void AddListEnemy()
    {
        var goEnemise = GameObject.FindGameObjectsWithTag("Enemy");
        _goEnemise = goEnemise.OrderBy(enemy => Vector3.Distance(this.transform.position, enemy.transform.position)).ToList();
    }
}
