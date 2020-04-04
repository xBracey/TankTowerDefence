using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTankDefinitions
{
    private Dictionary<Tanks, enemyTank> tanks;

    public enemyTankDefinitions()
    {
        tanks = new Dictionary<Tanks, enemyTank>();

        tanks.Add(Tanks.blueTank, new enemyTank("blueTank", 0.5f, 10));
        tanks.Add(Tanks.redTank, new enemyTank("redTank", 1f, 4));
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
