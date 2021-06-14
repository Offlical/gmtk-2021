using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private GameManager manager;
    public Text scoreText;
    public Text timeText;
    public Button resetButton;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void StartBtn()
    {
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        manager.gameEnd = false;
        gameObject.SetActive(false);
        manager.startTime = DateTime.Now;
    }
}
