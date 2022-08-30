using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Player player;

    public Text healthDisplay;
    public Text scoreText;

    public GameObject gameOverPanel;
    public GameObject gamePanel;

    public bool spawnAllowed = true;

    public int damagePoints = 5;
    public int killPoints = 10;
    public int score = 0;

    [SerializeField]
    private Spawner spawner;

    public GameObject gameOverTxt;
    public Text scoreGameOverTxt;

    public GameObject[] healthIcons;

    public bool gameOver = false;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthDisplay.text = "HEALTH: " + player.health.ToString();
        scoreText.text = "SCORE: " + score.ToString();

        if(player.health <= 20)
        {
            healthIcons[0].SetActive(false);
        }

        if (player.health <= 10)
        {
            healthIcons[1].SetActive(false);
        }

        if (!gameOver)
        {
            GameOver();
        }
        else
        {
            Destroy(GameObject.FindWithTag("Enemy"));
            spawnAllowed = false;
            gameOverPanel.SetActive(true);
            gamePanel.SetActive(false);
            scoreGameOverTxt.text = "SCORE: " + score;
        }
	}

    private void GameOver()
    {
        if(player.health <= 0)
        {
            player.SpawnDeathEffect();
            gameOver = true;
            Destroy(player.gameObject);
        }
    }
}
