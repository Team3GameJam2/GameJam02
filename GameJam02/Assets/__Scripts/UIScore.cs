using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{

    const float STARTSCORE = 0;
    float currentScore = 0;
    public Vector2 playerstartingHeight = new Vector2(0, 0);
    Text number;
    bool canPlay = false;

    bool resetGame = false;
    bool endGame = false;

    private GameObject player;
    public GameObject inGamePanel;
    public GameObject endGamePanel;

    // Use this for initialization
    void Awake()
    {
        number = GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");

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

        //debugging
        if (Input.GetKey(KeyCode.Space))
        {
            endGame = true;
        }

        if (endGame)
        {
            disableInGamepanel();
        }
        if (resetGame)
        {
            reset();
        }
    }

    public void reset()
    {
        resetGame = false;
        endGamePanel.SetActive(false);
        currentScore = STARTSCORE;

        player.transform.position = playerstartingHeight;

        number.text = currentScore.ToString();
        canPlay = true;
        inGamePanel.SetActive(true);
    }

    public void disableInGamepanel()
    {
        endGame = false;
        canPlay = false;

        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //player.GetComponent<basicMove>().setLeftF();
        //player.GetComponent<basicMove>().setRightF();

        inGamePanel.SetActive(false);
        endGamePanel.SetActive(true);
    }

    public void OnClickReset()
    {
        resetGame = true;
    }

    public void OnEndGame()
    {
        endGame = true;
    }
}
