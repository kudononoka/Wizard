using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�ڒn������s�����߂̃N���X</summary>

public class GroundJudgment : MonoBehaviour
{
    /// <summary>true�̎��n�ʂɐڒn���Ă��܂�</summary>
    bool isGround; public bool IsGround => isGround;
    /// <summary>�ڒn������s�����߂̃��C���[�ł�</summary>
    [Header("�n�ʂƂ݂Ȃ��I�u�W�F�N�g�̃��C���["), SerializeField] LayerMask layerMask;
    /// <summary>ray�̒���</summary>
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
