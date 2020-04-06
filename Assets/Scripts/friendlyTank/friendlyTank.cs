using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyTank : MonoBehaviour
{
    protected float radius = 1f;
    protected int fireTickRate = 30;
    protected int price = 100;

    public bool placed = false;

    int level = 1;
    int killCount = 0;
    int xp = 0;

    [SerializeField]
    Sprite bulletSprite;

    int ticker = 0;

    stats tankStats;

    private void Start()
    {
        tankStats = GameObject.Find("tankStats").GetComponent<stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ticker == fireTickRate && placed)
        {
            bool enemyTank = CheckEnemyTank();
            if (enemyTank)
            {
                ticker = 0;
            }
        }
        else if (placed)
        {
            ticker++;
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
        bulletScript.tankFiredFrom = gameObject.GetComponent<friendlyTank>();
    }

    private bool CheckEnemyTank()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        bool hitEnemyTank = false;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "enemyTank")
            {
                changeAngle(hitColliders[i].transform.position);
                createBullet(hitColliders[i].transform.position);
                return true;
            }
        }

        return false;
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

    public void AddKill()
    {
        killCount++;
        xp += 10;
        checkLevelUp();
    }

    void OnMouseDown()
    {
        checkLevelUp();
        tankStats.statSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        tankStats.sellNumber = price / 4;
        tankStats.upgradeNumber = price / 2;
        tankStats.levelNumber = level;
        tankStats.killCountNumber = killCount;
        tankStats.xpNumber = calculateXPLeft();
        tankStats.newStats = true;
    }

    void checkLevelUp()
    {
        int xpNeeded = level * 100;
        if (xp >= xpNeeded)
        {
            xp = xp - xpNeeded;
            level++;
        }
    }

    int calculateXPLeft()
    {
        int xpNeeded = level * 100;
        return xpNeeded - xp;
    }
}
