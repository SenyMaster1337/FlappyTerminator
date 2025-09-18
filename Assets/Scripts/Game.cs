using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BirdPlayer _bird;

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        //_endGameScreen.Open();
    }
}
