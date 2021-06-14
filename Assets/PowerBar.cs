using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerBar : MonoBehaviour
{

    public Motor motor;
    public Text usageText;
    public Text gasText;
    public Slider gasSlider;
    public Slider powerBar;

    private GameManager manager;
    private float gasPercent = -1;
    public Image gasFillRect;
    public Gradient gradient;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        gasPercent = motor.GetMaxGas() / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.gameEnd)
        {
            
            gasSlider.value = motor.GetGasContained() / gasPercent;
            UpdateBars();
        }
    }

    public void UpdateBars()
    {

        gasFillRect.color = gradient.Evaluate(gasSlider.normalizedValue);

        usageText.text = "POWER USAGE: " + powerBar.value.ToString("0") + "%";
        gasText.text = gasSlider.value.ToString("0.00") + "% POWER LEFT";
    }

    public void setMotor(Motor motor)
    {
        this.motor = motor;
    }
}
