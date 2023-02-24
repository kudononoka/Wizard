using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReset : StateMachineBehaviour
{
    [SerializeField,Header("AnimState‚ð‚Ê‚¯‚½‚çfalse‚É‚µ‚½‚¢bool")] string _triggerName;
    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    animator.SetBool(_triggerName, false);
    //}

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(_triggerName, false);
    }
}
