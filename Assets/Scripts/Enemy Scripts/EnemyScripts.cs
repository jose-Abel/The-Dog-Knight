using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    private GameObject[] players;
    private Rigidbody myBody;
    private Animator anim;

    private float enemy_Speed = 6f;
    private float enemy_Watch_Treshold = 15f;
    private float enemy_Attack_Treshold = 3f;

    public GameObject damagePoint;

    void Awake() {
        players = GameObject.FindGameObjectsWithTag(MyTags.PLAYER_TAG);

        myBody = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        EnemyAI();
    }

    void EnemyAI() {
        Vector3 directionToDog = players[0].transform.position - transform.position;

        Vector3 directionToFox = players[1].transform.position - transform.position;

        float distanceFromDog = directionToDog.magnitude;

        float distanceFromFox = directionToFox.magnitude;

        directionToDog.Normalize();

        directionToFox.Normalize();

        Vector3 velocity = directionToDog * enemy_Speed;

        if (distanceFromDog > enemy_Attack_Treshold && distanceFromDog < enemy_Watch_Treshold) {

            myBody.velocity = new Vector3(velocity.x, myBody.velocity.y, velocity.z);

            if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION)) {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.RUN_TRIGGER);

            transform.LookAt(new Vector3(players[0].transform.position.x, transform.position.y, players[0].transform.position.z));
        }

        else if (distanceFromDog < enemy_Attack_Treshold) {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION)) {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
            anim.SetTrigger(MyTags.ATTACK_1_ANIMATION);

            transform.LookAt(new Vector3(players[0].transform.position.x, transform.position.y, players[0].transform.position.z));

        }
        else if (distanceFromDog > enemy_Attack_Treshold && distanceFromFox < enemy_Attack_Treshold) {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION)) {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.ATTACK_1_ANIMATION);

            transform.LookAt(new Vector3(players[1].transform.position.x, transform.position.y, players[1].transform.position.z));
        }

        else {
            myBody.velocity = new Vector3(0f, 0f, 0f);

            if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION)) {

                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
        }
    }

    void ActivateDamagePoint() {
        damagePoint.SetActive(true);
    }

    void DeactivateDamagePoint() {
        damagePoint.SetActive(false);
    }
    
}
