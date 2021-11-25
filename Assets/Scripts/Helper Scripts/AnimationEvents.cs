using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject dogPlayer, foxPlayer, playButton;

    void DeactivateGameObjects() {
        dogPlayer.SetActive(false);
        foxPlayer.SetActive(false);
        playButton.SetActive(false);
    }

    void ActivateGameObjects() {
        dogPlayer.SetActive(true);
        foxPlayer.SetActive(true);
        playButton.SetActive(true);
    }
}
