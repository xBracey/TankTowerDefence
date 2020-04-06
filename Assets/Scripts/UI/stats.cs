using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour
{
    Text levelText, xpText, killCountText, upgradeText, sellText;
    Image statSpriteRenderer;

    public int levelNumber, xpNumber, killCountNumber, upgradeNumber, sellNumber = 0;
    public Sprite statSprite;

    public bool newStats = false;

    // Start is called before the first frame update
    void Start()
    {
        statSpriteRenderer = GameObject.Find("tankStatSprite").GetComponent<Image>();
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        xpText = GameObject.Find("xpText").GetComponent<Text>();
        killCountText = GameObject.Find("killCountText").GetComponent<Text>();
        upgradeText = GameObject.Find("upgradeText").GetComponent<Text>();
        sellText = GameObject.Find("sellText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (newStats)
        {
            newStats = false;

            statSpriteRenderer.sprite = statSprite;

            levelText.text = "Level " + levelNumber.ToString();
            xpText.text = xpNumber.ToString() + " XP to next level";
            killCountText.text = "Kill Count - " + killCountNumber.ToString();
            upgradeText.text = upgradeNumber.ToString();
            sellText.text = sellNumber.ToString();
            Move();
        }
    }

    private void Move()
    {
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
