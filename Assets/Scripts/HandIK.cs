using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour
{
    Animator _anim;
    [SerializeField, Range(0f, 1f)] float _rightPosWeigth;
    [SerializeField, Range(0f, 1f)] float _leftPosWeigth;
    [SerializeField,Range(0f ,1f)] float _rightRotWeigth;
    [SerializeField, Range(0f, 1f)] float _leftRotWeigth;
    [SerializeField] Transform _rightTarget;
    [SerializeField] Transform _leftTarget;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //âEéË
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightPosWeigth);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightRotWeigth);
        _anim.SetIKPosition(AvatarIKGoal.RightHand, _rightTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.RightHand,_rightTarget.rotation);
        //ç∂éË
        _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, _leftPosWeigth);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, _leftRotWeigth);
        _anim.SetIKPosition(AvatarIKGoal.LeftHand, _leftTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.LeftHand, _leftTarget.rotation);

    }
}
