using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>接地判定を行うためのクラス</summary>

public class GroundJudgment : MonoBehaviour
{
    /// <summary>trueの時地面に接地しています</summary>
    bool isGround; public bool IsGround => isGround;
    /// <summary>接地判定を行うためのレイヤーです</summary>
    [Header("地面とみなすオブジェクトのレイヤー"), SerializeField] LayerMask layerMask;
    /// <summary>rayの長さ</summary>
    float rayLength = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength, layerMask))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        
        
    }
}
