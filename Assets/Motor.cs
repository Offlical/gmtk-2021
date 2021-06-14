using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Motor 
{
    private float gasContained;
    private float maxGas;
    private float speed;
    private float maxSpeed = 20f;

    public static GameManager instance;

    public Motor(float gasContained, float maxSpeed)
    {
        this.gasContained = gasContained;
        this.maxSpeed = maxSpeed;
        this.maxGas = gasContained;
    }

    public void PowerMotor(float percent, Rigidbody2D rb, Transform loc, ParticleSystem particle)
    {
        speed = maxSpeed * (percent / 100);
        var em = particle.emission;
        if (gasContained <= (instance.gasUse * 10 * maxGas * Time.deltaTime))
        {
            em.enabled = false;
            speed = 0;
            return;
        }
        em.enabled = true;
        em.rateOverTime = 50 * (percent / 100);
        rb.AddForceAtPosition(new Vector2(0, speed * Time.deltaTime) , loc.position);
        gasContained -= (instance.gasUse * (speed / 100) * maxGas) * Time.deltaTime; 
    }

    public static void setGameManager(GameManager manager)
    {
        instance = manager;
    }
    public void FillGas()
    {
        if (speed > 0)
            return;
        if(gasContained < maxGas)
            gasContained += instance.gasGain * maxGas * Time.deltaTime;
    }

    public float GetGasContained()
    {
        return gasContained;
    }

    public float GetMaxGas()
    {
        return maxGas;
    }

    public float GetPercentFull()
    {
        return maxGas / (maxGas / 100);
    }

    public override bool Equals(object obj)
    {
        return obj is Motor motor &&
               gasContained == motor.gasContained &&
               maxGas == motor.maxGas &&
               speed == motor.speed &&
               maxSpeed == motor.maxSpeed;
    }
}
