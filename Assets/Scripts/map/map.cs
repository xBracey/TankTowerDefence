using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map : MonoBehaviour
{
    public GameObject tank;
    GameObject validPlacement;
    GameObject invalidPlacement;
    Text coin;

    private void Start()
    {
        GameObject coinObject = GameObject.Find("coins");
        coin = coinObject.GetComponent<Text>();

        validPlacement = GameObject.Find("validPlacement");
        invalidPlacement = GameObject.Find("invalidPlacement");
    }

    private void Update()
    {
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();

        if (collider.enabled)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            tank.transform.position = newPosition;
            float tankRadius = tank.GetComponent<friendlyTank>().getRadius();

            validPlacement.transform.localScale = new Vector3(tankRadius, tankRadius, 1);
            invalidPlacement.transform.localScale = new Vector3(tankRadius, tankRadius, 1);

            bool canPlaceTank = CanPlaceTank(newPosition);

            if (canPlaceTank)
            {
                validPlacement.transform.position = newPosition;
                invalidPlacement.transform.position = new Vector3(0, 10, 0);
            }
            else
            {
                invalidPlacement.transform.position = newPosition;
                validPlacement.transform.position = new Vector3(0, 10, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        bool canPlaceTank = CreateTank();

        if (canPlaceTank)
        {
            BoxCollider collider = gameObject.GetComponent<BoxCollider>();
            collider.enabled = false;

            tank.transform.position = new Vector3(0, 10, 0);
            validPlacement.transform.position = new Vector3(0, 10, 0);
            invalidPlacement.transform.position = new Vector3(0, 10, 0);
        }
    }

    private bool CreateTank()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        bool canPlaceTank = CanPlaceTank(newPosition);

        if (canPlaceTank)
        {
            int coinInt = Int32.Parse(coin.text);
            int tankPrice = tank.GetComponent<friendlyTank>().getPrice();

            if (coinInt >= tankPrice)
            {
                GameObject newTank = Instantiate(tank);
                newTank.transform.position = newPosition;
                SpriteRenderer renderer = newTank.GetComponent<SpriteRenderer>();
                renderer.sortingLayerName = "Foreground";

                BoxCollider collider = newTank.GetComponent<BoxCollider>();
                collider.enabled = true;

                coinInt += -tankPrice;
                coin.text = coinInt.ToString();
            }
        }

        return canPlaceTank;
    }

    private bool CanPlaceTank(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, 0.15f);
        bool canPlaceTank = true;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if ((hitColliders[i].gameObject.tag == "road" || hitColliders[i].gameObject.tag == "friendlyTank") && hitColliders[i].gameObject != tank)
            {
                canPlaceTank = false;
            }
        }

        return canPlaceTank;
    }
}
