using System;
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
        Debug.Log("StartEnemyStand");
        _coroutine = StartCoroutine(_EnemyStand());
    }

    IEnumerator _EnemyStand()
    {
        yield return new WaitForSeconds(_startWait);
        Debug.Log("_EnemyStand");
        while(true)
        {
            if (_enemies.Any(i=>i.IsStand == false))
            {
                var enemy = _enemies.Where(i => i.IsStand == false).OrderBy(qu => Guid.NewGuid()).FirstOrDefault(i=>i);
                enemy.EnemyStand();
                yield return new WaitForSeconds(_standWait); 
            }
            yield return null;
        }
    }

    public void EnemyAllStop()
    {
        if (_coroutine != null)
        {
            Debug.Log("EnemyAllStop");
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].IsStand = false;
            }
            StopCoroutine(_coroutine);
        }
    }
}
