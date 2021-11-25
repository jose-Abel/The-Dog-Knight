using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Animator levelPanelAnim;

    public void PlayGame() {
        levelPanelAnim.Play("SlideIn");
    }

    public void Back() {
        levelPanelAnim.Play("SlideOut");
    }

    public void StartGame() {
        SceneManager.LoadScene("DayScene");
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
