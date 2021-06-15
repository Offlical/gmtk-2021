using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform rocket;

    private GameManager manager;
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        Vector2 currentLoc = transform.position;
        currentLoc.x = rocket.position.x;

        transform.position = currentLoc;
        if (Vector2.Distance(transform.position, rocket.position) > 25)
            transform.position = rocket.position - new Vector3(0, 20,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.Die();
    }
}

