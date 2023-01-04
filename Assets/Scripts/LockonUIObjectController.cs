using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockonUIObjectController : MonoBehaviour
{
    /// <summary>mainCamera�̈ʒu</summary>
    Transform _mcTransform;
    RectTransform _rectTransform;
    PlayerLockon _playerLockon;

    Vector3 _dir;

    [SerializeField] float _raydistance = 1000;

    [SerializeField] LayerMask _layerMask;
    // Start is called before the first frame update
    void Start()
    {
        _mcTransform = Camera.main.GetComponent<Transform>();
        _playerLockon = FindObjectOfType<PlayerLockon>();
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_playerLockon.IsLockon)
        {
            _dir = _playerLockon.TargetPos.position - _mcTransform.position;
            _rectTransform.forward = _dir;
            Ray ray = new Ray(_mcTransform.position, _dir);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, _raydistance, _layerMask))
            {
                Vector3 point = (hit.point - _mcTransform.position) * 0.9f;
                //point.z += 1;
                Vector3 pos = _mcTransform.position + point;
                _rectTransform.position = pos;
            }
            Debug.DrawRay(_mcTransform.position, _dir, Color.red, _raydistance);
        }
    }
}
