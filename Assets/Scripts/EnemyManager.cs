using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies = null;
    [SerializeField] private float _startWait = 1f;
    [SerializeField] private float _standWait = .5f;

    private Coroutine _coroutine;
    
    public void StartEnemyStand()
    {
        _coroutine = StartCoroutine(_EnemyStand());
    }

    IEnumerator _EnemyStand()
    {
        yield return new WaitForSeconds(_startWait);
        while(_enemies.Any(i=>i.IsStand == false))
        {
            var enemy = _enemies.Where(i => i.IsStand == false).FirstOrDefault(i=>i);
            enemy.Stand();
            yield return new WaitForSeconds(_standWait);
        }
    }

    public void EnemyAllStop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
