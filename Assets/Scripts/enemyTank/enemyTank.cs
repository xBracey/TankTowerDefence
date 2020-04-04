using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTank
{
    private string tankObjectName;
    private float moveSpeed;
    private int health;

    public enemyTank(string tankObjectName, float moveSpeed, int health)
    {
        this.tankObjectName = tankObjectName;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

    public string GetTankObjectName()
    {
        return tankObjectName;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetHealth()
    {
        return health;
    }
}
