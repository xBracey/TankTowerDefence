using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    public Vector3 enemyTankPosition;

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
            Destroy(gameObject);
        }
    }
}
