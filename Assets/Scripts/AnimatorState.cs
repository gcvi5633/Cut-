/* 使用這個腳本的 Animator State Info 請掛上 AnimatorInfoState 這個 StateMachineBehaviour Script
 * 一個簡單易用(?)的腳本
 * Powered by RayX
 */
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof (Animator))]
public class AnimatorState : MonoBehaviour
{
    [SerializeField] Animator _animator = null;

    [Serializable]
    class AnimationStateEvent
    {
        /// <summary>
        /// AnimatorStateInfo 的名稱
        /// </summary>
        public string AnimatorStateName = string.Empty;
        /// <summary>
        /// AnimatorStateInfo 的階層
        /// </summary>
        public int Layer = 0;
        /// <summary>
        /// 符合條件的 OnStateEnter
        /// </summary>
        public UnityEvent Enter = null;
        /// <summary>
        /// 符合條件的 OnStateExit
        /// </summary>
        public UnityEvent Exit = null;
        /// <summary>
        /// 符合條件的 OnStateUpdate
        /// </summary>
        public UnityEvent Update = null;
        /// <summary>
        /// 符合條件的 OnStateIK
        /// </summary>
        public UnityEvent IK = null;
        /// <summary>
        /// 符合條件的 OnStateMove
        /// </summary>
        public UnityEvent Move = null;
    }

    [SerializeField] AnimationStateEvent[] _animationStateEvents = null;
    
    string _currentAnimatorStateName = string.Empty;
    void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    void Begin()
    {
        var animationStateEvent = GetAnimationStateEvent();
        if (animationStateEvent != null)
        {
            _currentAnimatorStateName = animationStateEvent.AnimatorStateName;
            animationStateEvent.Enter.Invoke();
        }
    }

    void Exit()
    {
        var animationStateEvent = GetAnimationStateEvent();
        if (animationStateEvent != null)
        {
            animationStateEvent.Exit.Invoke();
            _currentAnimatorStateName = string.Empty;
        }
    }

    void AnimationUpdate()
    {
        var animationStateEvent = GetAnimationStateEvent();
        if (animationStateEvent != null)
        {
            animationStateEvent.Update.Invoke();
        }
    }

    void IK()
    {
        var animationStateEvent = GetAnimationStateEvent();
        if (animationStateEvent != null)
        {
            animationStateEvent.IK.Invoke();
        }
    }

    void Move()
    { 
        var animationStateEvent = GetAnimationStateEvent();
        if (animationStateEvent != null)
        {
            animationStateEvent.Move.Invoke();
        }
    }

    AnimationStateEvent GetAnimationStateEvent()
    {
        for (int i = 0; i < _animationStateEvents.Length; i++)
        {
            var stateName = _animationStateEvents[i].AnimatorStateName;
            var layer = _animationStateEvents[i].Layer;
            if (_animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName))
            {
                return _animationStateEvents[i];
            }
            if (_animationStateEvents[i].AnimatorStateName == _currentAnimatorStateName)
            {
                return _animationStateEvents[i];
            }
        }
        return null;
    }
}
