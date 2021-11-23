using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    private EnemyScripts enemyScript;

    private Animator anim;

    void Awake()
    {
        enemyScript = GetComponent<EnemyScripts>();

        anim = GetComponent<Animator>();
    }

    public void ApplyDamage(int damageAmount) {
        anim.SetTrigger(MyTags.DAMAGE_TRIGGER);
        
        health -= damageAmount;

        if (health < 0) {
            health = 0;
        }

        if (health == 0) {
            enemyScript.enabled = false;

            anim.SetTrigger(MyTags.DEAD_TRIGGER);

            Invoke("DeactivateEnemy", 3f);
        }
    }

    void DeactivateEnemy() {
        gameObject.SetActive(false);
    }
}
