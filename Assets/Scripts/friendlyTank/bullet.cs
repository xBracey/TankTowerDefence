using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 8f;
    numberedText coins;

    public friendlyTank tankFiredFrom;
    public Vector3 enemyTankPosition;

    void Start()
    {
        coins = GameObject.Find("coins").GetComponent<numberedText>();
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemyTank();
    }

    private void GetEnemyTank()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            enemyTankPosition,
            moveSpeed * Time.deltaTime
        );

        if (transform.position == enemyTankPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collider.gameObject.tag == "enemyTank")
        {
            enemyTankGameObject tank = collider.gameObject.GetComponent<enemyTankGameObject>();
            tank.health += -1;
            coins.addNumber(1);
            if (tank.health == 0)
            {
                tankFiredFrom.AddKill();
            }
            Destroy(gameObject);
        }
    }
}
