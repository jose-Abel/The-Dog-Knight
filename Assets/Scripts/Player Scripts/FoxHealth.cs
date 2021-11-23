using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxHealth : MonoBehaviour
{
    public int health = 50;
    private FoxScript foxScript;
    private PlayerDamage[] playerDamageScripts;

    private Animator anim;

    void Awake()
    {
        foxScript = GetComponent<FoxScript>();

        anim = GetComponent<Animator>();

        playerDamageScripts = GetComponents<PlayerDamage>();
    }

    void Start() {
        GameplayController.instance.DisplayFoxHealth(health);
    }

    public void ApplyDamage(int damageAmount) {
        health -= damageAmount;

        if (health < 0) {
            health = 0;
        }

        // DISPLAY THE HEALTH VALUE
        GameplayController.instance.DisplayFoxHealth(health);

        if (health == 0) {
            anim.Play(MyTags.DEAD_TRIGGER);

            foreach (var playerDamage in playerDamageScripts)
            {
                playerDamage.enabled = false;
            }

            GameplayController.instance.isFoxAlive = false;

            foxScript.enabled = false;
        }
    }
}
