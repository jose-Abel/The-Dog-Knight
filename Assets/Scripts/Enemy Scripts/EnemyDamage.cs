using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 2;
    public LayerMask playerLayer;
    private Animator anim;

    void Start() {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.1f, playerLayer);

        if (hits.Length > 0) {

            if (hits[0].gameObject.tag == MyTags.PLAYER_TAG) {
              if (hits[0].gameObject.GetComponent<DogHealth>()) {
                hits[0].gameObject.GetComponent<DogHealth>().ApplyDamage(damageAmount);

                if (!GameplayController.instance.isDogAlive) {
                  anim.SetTrigger(MyTags.VICTORY_TRIGGER);
                }
              } else {
                hits[0].gameObject.GetComponent<FoxHealth>().ApplyDamage(damageAmount);
              }
            }
        }
    }
}
