using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    protected levels levels;
    protected bool playGame = false;
    protected int levelCounter = 1;
    protected bool finishedGame = false;
    protected bool allTanksSpawned = true;

    Transform[] waypoints;
    enemyTankDefinitions enemyTankDefinitions;
    Text levelCounterText;

    // Start is called before the first frame update
    protected void Start()
    {
        StoreWaypoints();
        enemyTankDefinitions = new enemyTankDefinitions();

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(StartLevel);

        levelCounterText = GameObject.Find("levelNumber").GetComponent<Text>();
        levelCounterText.text = levelCounter.ToString();
    }

    private void StoreWaypoints()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("waypoint");
        Array.Sort(waypointObjects, CompareObNames);

        waypoints = new Transform[waypointObjects.Length];

        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].transform;
        }
    }

    private int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

    async Task PutTaskDelay(int delay)
    {
        await Task.Delay(delay);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyTanks = GameObject.FindGameObjectsWithTag("enemyTank");
        if (levelCounter - 1 == levels.levelArray.Length)
        {
            finishedGame = true;
        }
        else if (allTanksSpawned && playGame && enemyTanks.Length == enemyTankDefinitions.GetNumberOfInactiveTanks())
        {
            levelCounter++;
            levelCounterText.text = levelCounter.ToString();
            playGame = false;
        }
    }

    public void StartLevel()
    {
        if (!playGame && !finishedGame)
        {
            allTanksSpawned = false;
            playGame = true;
            PlayLevel(levelCounter);
        }
    }

    async public void PlayLevel(int levelCounter)
    {
        string[] tanks = levels.levelArray[levelCounter - 1].tanks;

        for (int i = 0; i < tanks.Length; i++)
        {
            AddTank(GetTankName(tanks[i]));
            await PutTaskDelay(GetTankWait(tanks[i]));
        }

        allTanksSpawned = true;
    }

    public void AddTank(Tanks tankName)
    {
        enemyTank enemyTank = enemyTankDefinitions.GetTank(tankName);
        GameObject newTank = Instantiate(GameObject.Find(enemyTank.GetTankObjectName()));
        newTank.AddComponent(typeof(enemyTankGameObject));

        enemyTankGameObject newTankScript = newTank.GetComponent<enemyTankGameObject>();
        newTankScript.waypoints = waypoints;
        newTankScript.moveSpeed = enemyTank.GetMoveSpeed();
        newTankScript.health = enemyTank.GetHealth();
    }

    Tanks GetTankName(string tank)
    {
        string[] separator = { "-" };
        string[] tankStringSplit = tank.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return (Tanks)Int32.Parse(tankStringSplit[0]);
    }

    int GetTankWait(string tank)
    {
        string[] separator = { "-" };
        string[] tankStringSplit = tank.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return Int32.Parse(tankStringSplit[1]);
    }
}
