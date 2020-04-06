using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyTankGameObject : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 0.5f;
    int waypointIndex = 0;
    bool tankReachedEnd = false;
    public int health = 10;
    numberedText coins;
    numberedText lives;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sortingLayerName = "Foreground";

        coins = GameObject.Find("coins").GetComponent<numberedText>();

        lives = GameObject.Find("lives").GetComponent<numberedText>(); ;
    }

    private void Update()
    {
        if (!tankReachedEnd)
        {
            Move();
            FixRotation();
        }

        if (health <= 0)
        {
            coins.addNumber(10);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime
        );

        if (transform.position == waypoints[waypointIndex].transform.position && waypointIndex + 1 != waypoints.Length)
        {
            waypointIndex += 1;
        }
        else if (transform.position == waypoints[waypointIndex].transform.position && waypointIndex + 1 == waypoints.Length)
        {
            tankReachedEnd = true;
            lives.addNumber(-1);
            Destroy(gameObject);
        }
    }

    private void FixRotation()
    {
        Vector3 differenceVector = waypoints[waypointIndex].transform.position - transform.position;
        float z = 0;

        if (differenceVector.x > 0)
        {
            z = 90;
        }
        else if (differenceVector.x < 0)
        {
            z = 270;
        }
        else if (differenceVector.y > 0)
        {
            z = 180;
        }

        gameObject.transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y,
            z
        );
    }
}
