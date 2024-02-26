using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject normalUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text score;

    [SerializeField] private TMP_Text gameOverScore;

    [SerializeField] private Slider slider;


    private void Start()
    {
        gameManager.onGameOver.AddListener(GameOver);
        gameManager.pointsChanged.AddListener(PointsChanged);
        gameManager.newWave.AddListener(NewWave);

        NewWave();


    }
    private void NewWave()
    {
        normalUI.SetActive(true);
        gameOverUI.SetActive(false);
        score.text = "0.0";
        slider.minValue = 0f;
        slider.value = 0f;
        slider.maxValue = gameManager.GetMaxPoints();
    }
    private void PointsChanged(float points)
    {
        score.text = points.ToString("F2");

        slider.value = points;
    }
    private void GameOver(float points)
    {
        normalUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameOverScore.text = $"Score: {points:F2}";
    }

    public void Restart()
    {
        gameManager.Restart();
        NewWave();
    }

    public void Exit()
    {
        Application.Quit();
    }
}