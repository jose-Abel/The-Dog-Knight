using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHealth : MonoBehaviour
{
    public int health = 100;
    private DogScript dogScript;

    private Animator anim;

    void Awake()
    {
        dogScript = GetComponent<DogScript>();

        anim = GetComponent<Animator>();
    }

    public void ApplyDamage(int damageAmount) {
        health -= damageAmount;

        if (health < 0) {
            health = 0;
        }

        // DISPLAY THE HEALTH VALUE

        if (health == 0) {
            dogScript.enabled = false;

            anim.Play(MyTags.DEAD_TRIGGER);
        }
    }
}
