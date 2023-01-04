using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class PlayerLockon : MonoBehaviour
{
    List<GameObject> _goEnemise = new List<GameObject>();
    int _index;
    [Tooltip("���b�N�I���������̑Ώۂ̃Q�[���I�u�W�F�N�g")]Transform _targetPos; public Transform TargetPos => _targetPos;
    [SerializeField] CinemachineTargetGroup _group;
    [SerializeField, Tooltip("TargetGroup��target��weight")] float _weight;
    [SerializeField, Tooltip("TargetGroup��target��radius")] float _radius;
    [SerializeField, Header("���b�N�I������VC")] CinemachineVirtualCamera _virtualCamera;
    [SerializeField, Header("���i�g�����z�J����(FreeLook)")] CinemachineFreeLook _freelookCmera;
    /// <summary>True�̎��@���b�N�I����</summary>
    bool _isLockon = false; public bool IsLockon => _isLockon;
    // Start is called before the first frame update
    void Start()
    {
        AddListEnemy();
        _isLockon = false;
        _freelookCmera.MoveToTopOfPrioritySubqueue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("���b�N�I��");
            _isLockon = !_isLockon;
            if (_isLockon)
            {
                _virtualCamera.MoveToTopOfPrioritySubqueue();
                _targetPos = _goEnemise[_index].GetComponent<Transform>();
            }
            else
            {
                _freelookCmera.MoveToTopOfPrioritySubqueue();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isLockon)
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
            Vector3 pos = _targetPos.position;
            pos.y = 0;
           
            transform.rotation = Quaternion.LookRotation(pos);
        }
    }

    void AddListEnemy()
    {
        var goEnemise = GameObject.FindGameObjectsWithTag("Enemy");
        _goEnemise = goEnemise.OrderBy(enemy => Vector3.Distance(this.transform.position, enemy.transform.position)).ToList();
    }
}
