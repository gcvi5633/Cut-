using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationState : MonoBehaviour
{
    [SerializeField] UnityEvent _enter = null;
    [SerializeField] UnityEvent _exit = null;
    [SerializeField] UnityEvent _update = null;
    [SerializeField] UnityEvent _iK = null;
    [SerializeField] UnityEvent _move = null;

    void Begin()
    {
        _enter.Invoke();
    }

    void Exit()
    {
        _exit.Invoke();
    }

    void AnimationUpdate()
    {
        _update.Invoke();
    }

    void IK()
    {
        _iK.Invoke();
    }

    void Move()
    {
        _move.Invoke();
    }
}
