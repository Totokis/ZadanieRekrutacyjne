using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;

    [SerializeField] private TargetManager targetManager;
    private int _currentWaveIndex;
    private float _sumOfPoints;

    private void Start()
    {
        _currentWaveIndex = 0;
        targetManager.Restart(waves[_currentWaveIndex]);
    }
    public void AddPoints(float points)
    {
        _sumOfPoints += points;
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
            }
        }

    }
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}