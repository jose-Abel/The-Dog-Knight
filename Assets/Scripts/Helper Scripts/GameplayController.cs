using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text healthDogText, healthFoxText, enemyCounterText, scoreText;

    private int score = 0;

    private float enemyCounter = 10f;

    [HideInInspector]
    public bool isDogAlive;

    [HideInInspector]
    public bool isFoxAlive;

    
    void Awake()
    {
        MakeInstance();

        scoreText = GameObject.Find("Score").GetComponent<Text>();

        healthDogText = GameObject.Find("DogHealth").GetComponent<Text>();

        healthFoxText = GameObject.Find("FoxHealth").GetComponent<Text>();

        enemyCounterText = GameObject.Find("EnemyCounter").GetComponent<Text>();

        scoreText.text = "Score: " + score;
    }

    void Start() {
        isDogAlive = true;
        isFoxAlive = true;
    }

    void MakeInstance() {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy (gameObject);
        }
    }

    public void scoreIncremented() {
        score++;
        
        scoreText.text = "Score: " + score;
    }

    public void DisplayDogHealth(int health) {
        healthDogText.text = "Health: " + health;
    }

    public void DisplayFoxHealth(int health) {
        healthFoxText.text = "Health: " + health;
    }

    public void CountDownEnemies() {
        enemyCounter--;

        enemyCounterText.text = "Enemy Counter: " + enemyCounter;
    }
}