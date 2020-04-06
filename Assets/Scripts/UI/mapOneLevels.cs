using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapOneLevels : levelManager
{
    void Start()
    {
        base.Start();
        levels = JsonUtility.FromJson<levels>(File.ReadAllText("Assets/Levels/mapOne.json"));

        Debug.Log(levels.levelArray[0].tanks);
    }
}
