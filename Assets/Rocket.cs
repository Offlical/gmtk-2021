using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private GameManager manager;

    public Rigidbody2D rb;

    public Vector2 maxVelocity;

    public Transform rightMotor;
    public Transform middleMotor;
    public Transform leftMotor;

    public ParticleSystem leftParticle;
    public ParticleSystem rightParticle;
    public ParticleSystem middleParticle;


    // Start is called before the first frame update
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.gameEnd) manager.PowerRocket(this);
        if (rb.velocity.x > maxVelocity.x || rb.velocity.y > maxVelocity.y)
            rb.velocity = maxVelocity;
    }
}
