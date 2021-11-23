using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text healthText, timerText, scoreText;

    private int score;

    [HideInInspector]
    public bool isDogAlive;

    [HideInInspector]
    public bool isFoxAlive;

    public float timerTime = 99f;
    
    void Awake()
    {
        MakeInstance();

        healthText = GameObject.Find("Health Text").GetComponent<Text>();

        timerText = GameObject.Find("Timer Text").GetComponent<Text>();

        scoreText.text = "Score: " + score;
    }

    void Start() {
        isDogAlive = true;
    }

    void Update() {
        CountdownTimer();
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

    public void DisplayHealth(int health) {
        healthText.text = "Health: " + health;
    }

    void CountdownTimer() {
        timerTime -= Time.deltaTime;

        timerText.text = "Time: " + timerTime.ToString("F0");
    }
}