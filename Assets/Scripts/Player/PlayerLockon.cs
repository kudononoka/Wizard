using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class PlayerLockon : MonoBehaviour
{
    List<GameObject> _goEnemise = new List<GameObject>();
    int _index;
    [Tooltip("���b�N�I���������̑Ώۂ̃Q�[���I�u�W�F�N�g")]GameObject _target;
    [SerializeField] CinemachineTargetGroup _group;
    [SerializeField, Tooltip("TargetGroup��target��weight")] float _weight;
    [SerializeField, Tooltip("TargetGroup��target��radius")] float _radius;
    [SerializeField, Header("���b�N�I������VC")] CinemachineVirtualCamera _virtualCamera;
    [SerializeField, Header("���i�g�����z�J����(FreeLook)")] CinemachineFreeLook _freelookCmera;
    /// <summary>True�̎��@���b�N�I����</summary>
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
            Debug.Log("���b�N�I��");
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
            Debug.Log("���b�N�I��");
        }
    }

    void AddListEnemy()
    {
        var goEnemise = GameObject.FindGameObjectsWithTag("Enemy");
        _goEnemise = goEnemise.OrderBy(enemy => Vector3.Distance(this.transform.position, enemy.transform.position)).ToList();
    }
}
