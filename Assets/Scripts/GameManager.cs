using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text _scoreText = null;
    [SerializeField]
    Text _lifeText = null;
    [SerializeField]
    int _originLife = 0;
    [SerializeField]
    UnityEvent _gameInit = null;
    [SerializeField]
    UnityEvent _addScore = null;
    [SerializeField]
    UnityEvent _minusLife = null;
    [SerializeField]
    UnityEvent _endGame = null;
    
    private int _score = 0;
    private int _life = 0;
    /// <summary>
    /// 剛開始載入遊戲
    /// </summary>
    public void InitializeGame()
    {
        _scoreText.text = _score.ToString("N0");
        _lifeText.text = _life.ToString("N0");
        _gameInit.Invoke();
    }
    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="score">傳入的分數</param>
    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString("N0");
        _addScore.Invoke();
    }

    /// <summary>
    /// 扣血
    /// </summary>
    public void MinusLife()
    {
        _life--;
        if (_life <= 0)
        {
            _life = 0;
        }
        _lifeText.text = _life.ToString("N0");
        _minusLife.Invoke();
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    void EndGame()
    {
        _endGame.Invoke();
    }

    public void CheckLife()
    {
        if (_life <= 0)
        {
            EndGame();
        }
    }

    public void ResetParameter()
    {
        _score = 0;
        _life = _originLife;
    }
}
