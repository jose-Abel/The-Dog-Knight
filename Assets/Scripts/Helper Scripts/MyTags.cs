using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTags : MonoBehaviour
{
  // DOG ANIMATIONS
  public static string IDLE = "Idle";
  public static string RUN_ANIMATION = "Run";
  public static string ATTACK_1_RUNNING_ANIMATION = "AttackRunning1";
  public static string ATTACK_2_RUNNING_ANIMATION = "AttackRunning2";
  public static string WALK_ANIMATION = "Walk";
  public static string ATTACK_1_ANIMATION = "Attack1";
  public static string ATTACK_2_ANIMATION = "Attack2";
  public static string DEFEND_ANIMATION = "Defend";
  public static string DEAD_ANIMATION = "Dead";

  // FOX ANIMATIONS
  public static string STANDUP_ANIMATION = "Standup";
  public static string SIT_ANIMATION = "Sit";

  // ENEMY ANIMATIONS
  public static string VICTORY_ANIMATION = "Victory";

  // DOG TRIGGERS
  public static string RUN_TRIGGER = "Run";
  public static string ATTACK_1_RUNNING_TRIGGER = "AttackRunning1";
  public static string ATTACK_2_RUNNING_TRIGGER = "AttackRunning2";
  public static string WALK_TRIGGER = "Walk";
  public static string STOP_TRIGGER = "Stop";
  public static string ATTACK_1_TRIGGER = "Attack1";
  public static string ATTACK_2_TRIGGER = "Attack2";
  public static string DEFEND_TRIGGER = "Defend";
  public static string STOP_DEFEND_TRIGGER = "StopDefend";
  public static string DEAD_TRIGGER = "Dead";

  // FOX TRIGGERS
  public static string STANDUP_TRIGGER = "Standup";
  public static string SIT_TRIGGER = "Sit";
  public static string STOP_RUN_TRIGGER = "StopRun";
  public static string STOP_ATTACK_TRIGGER = "StopAttack";

  // ENEMY TRIGGERS
  public static string DAMAGE_TRIGGER = "Damage";
  public static string VICTORY_TRIGGER = "Victory";


  // TAGS
  public static string PLAYER_TAG = "Player";
  public static string ENEMY_TAG = "Enemy";
}
