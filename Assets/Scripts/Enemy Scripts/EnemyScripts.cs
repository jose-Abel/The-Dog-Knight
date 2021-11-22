using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    private GameObject player;
    private Rigidbody myBody;
    private Animator anim;

    private float enemy_Speed = 6f;
    private float enemy_Watch_Treshold = 15f;
    private float enemy_Attack_Treshold = 3f;

    void Awake() {
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);

        myBody = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        EnemyAI();
    }

    void EnemyAI() {
        Vector3 direction = player.transform.position - transform.position;

        float distance = direction.magnitude;

        direction.Normalize();

        Vector3 velocity = direction * enemy_Speed;

        if (distance > enemy_Attack_Treshold && distance < enemy_Watch_Treshold) {

            myBody.velocity = new Vector3(velocity.x, myBody.velocity.y, velocity.z);

            if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION)) {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }

            anim.SetTrigger(MyTags.RUN_TRIGGER);

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }

        else if (distance < enemy_Attack_Treshold) {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION)) {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
            anim.SetTrigger(MyTags.ATTACK_1_ANIMATION);

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }

        else {
            myBody.velocity = new Vector3(0f, 0f, 0f);

            if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION)) {

                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
        }
    }
    
}
