using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasRotate : MonoBehaviour
{
    RectTransform _rectTransform;
    GameObject _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.rotation = Quaternion.LookRotation(_mainCamera.transform.forward);
    }
}
