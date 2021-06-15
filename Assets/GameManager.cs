using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Motor rightMotor;
    public Motor middleMotor;
    public Motor leftMotor;

    public PowerBar rightBar;
    public PowerBar leftBar;
    public PowerBar middleBar;

    public float gasGain = 0.0007f;
    public float gasUse = 0.0001f;

    public Text endScoreText;
    public Text highScoreText;

    private StartButton startButton;
    public GameObject rocket;
    public GameObject endScreen;

    public float score = 0;
    public bool gameEnd = true;

    public Text timeText;
    private TimeSpan timeSince;
    public DateTime startTime;

    private void Awake()
    {
        startButton = FindObjectOfType<StartButton>();
        rightBar = GameObject.FindGameObjectWithTag("RightMotor").GetComponent<PowerBar>();
        leftBar = GameObject.FindGameObjectWithTag("LeftMotor").GetComponent<PowerBar>();
        middleBar = GameObject.FindGameObjectWithTag("MiddleMotor").GetComponent<PowerBar>();

        Motor.setGameManager(this);
        SetupMotors();
    }

    public void Die()
    {
        if (gameEnd)
            return;
        gameEnd = true;
        endScreen.SetActive(true);
        rocket.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        highScoreText.text = "New high score!";
        if (!PlayerPrefs.HasKey("_highScore"))
            PlayerPrefs.SetFloat("_highScore", score);
        else if (PlayerPrefs.GetFloat("_highScore") < score)
            PlayerPrefs.SetFloat("_highScore", score);
        else
            highScoreText.text = "Highest Score: " + PlayerPrefs.GetFloat("_highScore").ToString("0");

        endScoreText.text = "Score: " + score.ToString("0");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetUIButtons()
    {
        rightBar.powerBar.value = rightBar.powerBar.minValue;
        leftBar.powerBar.value = rightBar.powerBar.minValue;
        middleBar.powerBar.value = rightBar.powerBar.minValue;

        rightBar.UpdateBars();
        leftBar.UpdateBars();
        middleBar.UpdateBars();
    }

    public void ResetStartButton()
    {
        startButton.gameObject.SetActive(true);

        startButton.timeText.gameObject.SetActive(false);
        startButton.scoreText.gameObject.SetActive(false);
        startButton.resetButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(!gameEnd) { 
          if(rightBar.powerBar.value < 15) rightMotor.FillGas();
          if (middleBar.powerBar.value < 15) middleMotor.FillGas();
          if (leftBar.powerBar.value < 15) leftMotor.FillGas();

          startButton.scoreText.text = "HEIGHT: " + rocket.transform.position.y.ToString("0") + " M";
          score = rocket.transform.position.y;
         timeSince = DateTime.Now - startTime;
         timeText.text = "TIME: " + String.Format("{0:00}:{1:00}", timeSince.Minutes, timeSince.Seconds);
        }
    }
    public void PowerRocket(Rocket r)
    {
        rightMotor.PowerMotor(rightBar.powerBar.value, r.rb, r.rightMotor,r.rightParticle);
        leftMotor.PowerMotor(leftBar.powerBar.value, r.rb, r.leftMotor,r.leftParticle);
        middleMotor.PowerMotor(middleBar.powerBar.value, r.rb, r.middleMotor,r.middleParticle);

    }
    public void SetupMotors()
    {
        rightMotor = new Motor(1000000, 1000);
        middleMotor = new Motor(1000000, 1000);
        leftMotor = new Motor(1000000, 1000);

        rightBar.setMotor(rightMotor);
        leftBar.setMotor(leftMotor);
        middleBar.setMotor(middleMotor);
    }

    public void ReduceBarForMotor(Motor motor, float val)
    {
        if (rightBar.motor == motor)
            rightBar.powerBar.value -= val;
        else if (leftBar.motor == motor)
            leftBar.powerBar.value -= val;
        else
            middleBar.powerBar.value -= val;
    }

}
