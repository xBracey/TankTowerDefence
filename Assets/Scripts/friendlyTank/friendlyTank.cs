using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyTank : MonoBehaviour
{
    protected float radius = 1f;
    protected int fireTickRate = 30;
    protected int price = 100;

    [SerializeField]
    Sprite bulletSprite;

    int ticker = 0;

    // Update is called once per frame
    void Update()
    {
        ticker++;

        if (ticker == fireTickRate)
        {
            ticker = 0;
            CheckEnemyTank();
        }
    }

    public int getPrice()
    {
        return price;
    }

    public float getRadius()
    {
        return radius;
    }

    private void createBullet(Vector3 enemyTankPosition)
    {
        GameObject bullet = new GameObject("Bullet");
        bullet.transform.eulerAngles = gameObject.transform.eulerAngles;

        SpriteRenderer renderer = bullet.AddComponent<SpriteRenderer>();
        renderer.sprite = bulletSprite;
        renderer.sortingLayerName = "Foreground";
        bullet.transform.position = transform.position;
        bullet.AddComponent(typeof(bullet));
        BoxCollider collider = bullet.AddComponent<BoxCollider>();

        collider.isTrigger = true;

        bullet bulletScript = bullet.GetComponent<bullet>();
        bulletScript.enemyTankPosition = enemyTankPosition;
    }

    private void CheckEnemyTank()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        int i = 0;
        bool hitEnemyTank = false;

        while (i < hitColliders.Length && !hitEnemyTank)
        {
            if (hitColliders[i].gameObject.tag == "enemyTank")
            {
                changeAngle(hitColliders[i].transform.position);
                createBullet(hitColliders[i].transform.position);
                hitEnemyTank = true;
            }
            i++;
        }
    }

    private void changeAngle(Vector3 enemyTankPosition)
    {
        Vector3 positionVector = enemyTankPosition - transform.position;
        Vector3 horizontalVector = new Vector3(1, 0, 0);

        float z = Vector3.Angle(positionVector, horizontalVector);
        float y = 0f;

        if (positionVector.y < 0)
        {
            z = 90 - z;
        }
        else
        {
            z = z + 90;
        }

        gameObject.transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y,
            z
        );

    }
}
