using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReset : StateMachineBehaviour
{
    [SerializeField,Header("AnimState���ʂ�����false�ɂ�����bool")] string _triggerName;
    [SerializeField, Header("AnimState���ʂ�����Off�ɂ�����trigger")] string attack;
    //OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.ResetTrigger(attack);
    //}

    //public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.SetBool(_triggerName, false);
    //}

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(attack);
    }
}
