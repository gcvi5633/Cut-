using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnter : StateMachineBehaviour
{
    private void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SendMessage("Begin");
    }
}
