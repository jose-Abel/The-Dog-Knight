using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxScript : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private Rigidbody myBody;
    private Animator anim;

    private float fox_Speed = 10f;
    private float fox_Watch_Treshold = 8f;
    private float fox_Watch_Enemy_Treshold = 15f;
    private float fox_Attack_Treshold = 3f;
    private bool attack_Mode = false;

    void Awake() {
      player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);

      enemy = GameObject.FindGameObjectWithTag(MyTags.ENEMY_TAG);

      myBody = GetComponent<Rigidbody>();

      anim = GetComponent<Animator>();
    }

    void Update() {
      if (!attack_Mode) {
            AI();
      }
      AttackAI();
      PressingKeys();
      Debug.Log(attack_Mode);
    }

    void AI() {
      Vector3 directionTowardsPlayer = player.transform.position - transform.position;
        
      float distanceWithPlayer = directionTowardsPlayer.magnitude;

      directionTowardsPlayer.Normalize();

      Vector3 velocityTowardPlayer = directionTowardsPlayer * fox_Speed;

      if (distanceWithPlayer > fox_Watch_Treshold) {

          myBody.velocity = new Vector3(velocityTowardPlayer.x, myBody.velocity.y, velocityTowardPlayer.z);

          if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.SIT_ANIMATION)) {
              anim.SetTrigger(MyTags.STANDUP_TRIGGER);
          }            

          anim.SetTrigger(MyTags.RUN_TRIGGER);

          transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
      }
      else if(distanceWithPlayer <= fox_Watch_Treshold) {
          if(anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_TRIGGER)) {
              anim.SetTrigger(MyTags.STOP_RUN_TRIGGER);
          }

          anim.SetTrigger(MyTags.SIT_TRIGGER);
      }
    }

    void AttackAI() {
      if (attack_Mode) {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.SITTING_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.SIT_ANIMATION)) {
        
          anim.SetTrigger(MyTags.STANDUP_TRIGGER);
        
        }

        Vector3 directionTowardsEnemy = enemy.transform.position - transform.position;

        float distanceWithEnemy = directionTowardsEnemy.magnitude;

        directionTowardsEnemy.Normalize();
                    
        Vector3 velocityTowardEnemy = directionTowardsEnemy * fox_Speed;

        if (distanceWithEnemy > fox_Attack_Treshold && distanceWithEnemy < fox_Watch_Enemy_Treshold) {
          myBody.velocity = new Vector3(velocityTowardEnemy.x, myBody.velocity.y, velocityTowardEnemy.z);

          if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_ANIMATION)) {

              anim.SetTrigger(MyTags.STOP_ATTACK_TRIGGER);
          }

          anim.SetTrigger(MyTags.RUN_ANIMATION);

          transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
        }
        else if (distanceWithEnemy < fox_Attack_Treshold) {
          if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION)) {
              anim.SetTrigger(MyTags.STOP_RUN_TRIGGER);
          }

          anim.SetTrigger(MyTags.ATTACK_1_ANIMATION);

          transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));                
        }
      }
    }

    void PressingKeys() {
      if (Input.GetKeyDown(KeyCode.RightControl)) {
        attack_Mode = true;
      }

      if (Input.GetKeyDown(KeyCode.RightShift)) {
        attack_Mode = false;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_ANIMATION)) {

            anim.ResetTrigger(MyTags.ATTACK_1_TRIGGER);
            anim.SetTrigger(MyTags.STOP_ATTACK_TRIGGER);
        }
      }
    }
}