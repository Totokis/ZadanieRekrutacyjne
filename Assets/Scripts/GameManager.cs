using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;

    [SerializeField] private TargetManager targetManager;

    public UnityEvent onGameOver;
    public UnityEvent pointsChanged;
    private int _currentWaveIndex;
    private float _sumOfPoints;

    private void Start()
    {
        Restart();
    }
    private void Restart()
    {
        _currentWaveIndex = 0;
        pointsChanged.Invoke();
        targetManager.Restart(waves[_currentWaveIndex]);
    }
    public void AddPoints(float points)
    {
        _sumOfPoints += points;
        pointsChanged.Invoke();
        CheckForEnd();
    }
    private void CheckForEnd()
    {
        if (_sumOfPoints >= waves[_currentWaveIndex].pointLimit)
        {
            if (_currentWaveIndex < waves.Count - 1)
            {
                _currentWaveIndex++;
                targetManager.Restart(waves[_currentWaveIndex]);
                Debug.Log("NextWave");
            }
        }

    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        onGameOver.Invoke();
    }
}