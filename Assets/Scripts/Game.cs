using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BirdPlayer _bird;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.OnButtonClicked += OnPlayButtonClick;
        _endGameScreen.OnButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.OnButtonClicked -= OnPlayButtonClick;
        _endGameScreen.OnButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Start()
    {
        _endGameScreen.gameObject.SetActive(false);
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.gameObject.SetActive(true);
        _endGameScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
        _enemySpawner.ReleaseAllObjectsToPool();
    }
}
