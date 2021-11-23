using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text healthDogText, healthFoxText;

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

    public void DisplayDogHealth(int health) {
        healthDogText.text = "Dog Health: " + health;
    }

    public void DisplayFoxHealth(int health) {
        healthFoxText.text = "Fox Health: " + health;
    }
}