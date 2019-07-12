using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExit : StateMachineBehaviour
{
    private void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SendMessage("Exit");
    }
}
