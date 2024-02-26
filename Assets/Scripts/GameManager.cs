using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<Wave> waves;

    [SerializeField] private TargetManager targetManager;

    public UnityEvent<float> onGameOver;
    public UnityEvent<float> pointsChanged;
    public UnityEvent newWave;
    private int _currentWaveIndex;
    private float _sumOfPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        _currentWaveIndex = 0;
        _sumOfPoints = 0f;
        pointsChanged.Invoke(_sumOfPoints);
        targetManager.Restart(waves[_currentWaveIndex]);
    }
    public void AddPoints(float points)
    {
        _sumOfPoints += points;
        pointsChanged.Invoke(_sumOfPoints);
        CheckForEnd();
    }
    private void CheckForEnd()
    {
        if (_sumOfPoints >= waves[_currentWaveIndex].pointLimit)
        {
            if (_currentWaveIndex < waves.Count - 1)
            {
                _sumOfPoints = 0f;
                _currentWaveIndex++;
                newWave.Invoke();
                targetManager.Restart(waves[_currentWaveIndex]);
                Debug.Log("NextWave");
            }
        }

    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        onGameOver.Invoke(_sumOfPoints);
    }
    public float GetMaxPoints()
    {
        return waves[_currentWaveIndex].pointLimit;
    }
}