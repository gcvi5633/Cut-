using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _standSpeed = 0;
    [SerializeField]
    float _fallDownSpeed = 0;
    [SerializeField]
    float _acttackWait = 0;
    [SerializeField]
    UnityEvent _attacked = null;
    [SerializeField]
    UnityEvent _beKilled = null;
    
    Collider2D _collider2D = null;
    Animator _animator = null;
    Coroutine _coroutine = null;

    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("Test Stand")]
    public void EnemyStand()
    {
        _animator.SetTrigger("Up");
    }

    public void Stand()
    {
        _coroutine = StartCoroutine(_Attack());
    }

    IEnumerator _Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(_acttackWait);
            _attacked.Invoke();
        }
    }

    [ContextMenu("Test fall down")]
    void BeAttacked()
    {
        StopCoroutine(_coroutine);
        _animator.SetTrigger("Down");
        _beKilled.Invoke();
    }
}
