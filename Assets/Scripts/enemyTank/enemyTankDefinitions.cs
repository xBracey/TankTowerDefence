using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Tanks
{
    redTank = 0,
    blueTank = 1,
    bigRedTank = 2,
    greenTank = 3,
}


public class enemyTankDefinitions
{
    private Dictionary<Tanks, enemyTank> tanks;

    public enemyTankDefinitions()
    {
        tanks = new Dictionary<Tanks, enemyTank>();

        tanks.Add(Tanks.blueTank, new enemyTank("blueTank", 0.6f, 10));
        tanks.Add(Tanks.redTank, new enemyTank("redTank", 1f, 4));
        tanks.Add(Tanks.bigRedTank, new enemyTank("bigRedTank", 0.4f, 15));
        tanks.Add(Tanks.greenTank, new enemyTank("greenTank", 1.5f, 4));
    }

    public enemyTank GetTank(Tanks tankName)
    {
        return tanks[tankName];
    }

    public int GetNumberOfInactiveTanks()
    {
        return tanks.Count;
    }
}
