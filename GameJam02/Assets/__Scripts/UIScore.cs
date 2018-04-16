using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour {

    const float STARTSCORE = 0;
    float currentScore = 0;
    public Vector2 playerstartingHeight = new Vector2(0, 0);
    Text number;
    bool canPlay = false;

    public GameObject player;
    public GameObject inGamePanel;
    public GameObject endGamePanel;

    // Use this for initialization
    void Awake ()
    {
        number = GetComponent<Text>();

        playerstartingHeight.y = player.transform.position.y;

        reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            currentScore = playerstartingHeight.y - player.transform.position.y;
            number.text = currentScore.ToString("F2");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reset();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            disableInGamepanel();
        }
    }

    public void reset()
    {
        endGamePanel.SetActive(false);
        currentScore = STARTSCORE;
        player.transform.position = playerstartingHeight;
        number.text = currentScore.ToString();
        canPlay = true;
        inGamePanel.SetActive(true);
    }

    public void disableInGamepanel()
    {
        canPlay = false;

        inGamePanel.SetActive(false);
        endGamePanel.SetActive(true);
    }
}
