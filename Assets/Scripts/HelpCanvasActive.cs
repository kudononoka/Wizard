using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCanvasActive : MonoBehaviour
{
    [SerializeField] GameObject _helpCanvas;
    bool _isCanvas = false;
    // Start is called before the first frame update
    void Start()
    {
        _helpCanvas.SetActive(_isCanvas);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Wait()
    {
        _isCanvas = !_isCanvas;
        _helpCanvas.SetActive(_isCanvas);
    }
}
