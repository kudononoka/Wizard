using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojisan : MonoBehaviour
{
    Rigidbody _rb;
    Animator _anim;
    [SerializeField] float _speed = 10;
    // Start is called before the first frame update
    void Start()
    {
            _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector3(x * _speed ,0,z * _speed);

        _anim.SetFloat("YokoWalk" , x);
        _anim.SetInteger("YokoWalk 0", (int)x);

        _anim.SetInteger("run" , (int)z);
    }
}
