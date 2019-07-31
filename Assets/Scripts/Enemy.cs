using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour,IPointerEnterHandler
{
    [SerializeField]
    float _attackWait = 0;
    [SerializeField]
    UnityEvent _attacked = null;
    [SerializeField]
    UnityEvent _beKilled = null;

    bool _isStand = false;

    public bool IsStand
    {
        get { return _isStand; }
        set { _isStand = value; }
    }

    Animator _animator = null;
    Coroutine _coroutine = null;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("Test Stand")]
    public void EnemyStand()
    {
        _animator.SetTrigger("Up");
    }

    public void Stand()
    {
        _isStand = true;
        _coroutine = StartCoroutine(_Attack());
    }

    IEnumerator _Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(_attackWait);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isStand)
        {
            _isStand = false;
            BeAttacked();
        }
    }
}
