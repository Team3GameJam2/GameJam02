using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour
{

    const float STARTSCORE = 0;
    float currentScore = 0;
    public Vector2 playerstartingHeight = new Vector2(0, 0);
    Text number;

    public AudioClip WispSound;


    [SerializeField]
    bool endGame = false;

    GameObject player;
    //public GameObject inGamePanel;
    public GameObject endGamePanel;

    // Use this for initialization
    void Awake()
    {
        number = GetComponent<Text>();
        number.text = STARTSCORE.ToString("F2");
        player = GameObject.FindGameObjectWithTag("Player");

        playerstartingHeight.y = player.transform.position.y;
        playerstartingHeight.x = player.transform.position.x;

        player.GetComponent<_Movement>().onDeath += DelayedReset;

        endGame = false;
        endGamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = playerstartingHeight.y - player.transform.position.y;
        if (currentScore <= 0)
            currentScore = 0;

        number.text = currentScore.ToString("F2");
    }

    public void DelayedReset()
    {
        Invoke("ResetGame", 1.0f);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonClicked()
    {
        endGamePanel.SetActive(false);
        player.GetComponent<AudioSource>().PlayOneShot(WispSound);
    }
}
