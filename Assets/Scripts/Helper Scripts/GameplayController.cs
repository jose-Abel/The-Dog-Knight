using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text healthDogText, healthFoxText, timerText;

    [HideInInspector]
    public bool isDogAlive;

    [HideInInspector]
    public bool isFoxAlive;

    public float timerTime = 99f;

    public GameObject endPanel;
    
    void Awake()
    {
        MakeInstance();

        timerText = GameObject.Find("Timer").GetComponent<Text>();

        healthDogText = GameObject.Find("DogHealth").GetComponent<Text>();

        healthFoxText = GameObject.Find("FoxHealth").GetComponent<Text>();
    }

    void Start() {
        isDogAlive = true;
        isFoxAlive = true;

        endPanel.SetActive(false);
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

    public void DisplayDogHealth(int health) {
        healthDogText.text = "Dog Health: " + health;
    }

    public void DisplayFoxHealth(int health) {
        healthFoxText.text = "Fox Health: " + health;
    }

    void CountdownTimer() {
        timerTime -= Time.deltaTime;

        timerText.text = "Time: " + timerTime.ToString("F0");

        if(timerTime <= 0) {
            GameOver();
        }
    }

    public void GameOver() {
        endPanel.SetActive(true);
    }    
}