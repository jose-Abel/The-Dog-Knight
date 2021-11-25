using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
  private Rigidbody myBody;
  private Animator anim;
  public Transform groundCheck;
  public LayerMask groundLayer;
  public GameObject damagePoint;
  public bool isDefending;
  bool isPlayerMoving;

  float playerSpeed = 0.1f;

  float rotationSpeed = 4f;

  float moveHorizontal, moveVertical;

  float rotY = 0f;

  void Awake()
  {
    myBody = GetComponent<Rigidbody>();
    anim = GetComponent<Animator>();
  }
  // Start is called before the first frame update
  void Start()
  {
    rotY = transform.localRotation.eulerAngles.y;
  }

  // Update is called once per frame
  void Update()
  {
    if (!isDefending) {
      PlayerMoveKeyboard();
      MoveAndRotate();
    }
    AnimatePlayer();
    Attack();
    Defend();
  }

  void PlayerMoveKeyboard()
  {
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      moveHorizontal = -1;
    }

    if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
    {
      moveHorizontal = 0;
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    {
      moveHorizontal = 1;
    }

    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
    {
      moveHorizontal = 0;
    }

    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    {
      moveVertical = 1;
    }

    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
    {
      moveVertical = 0;
    }
  }

  void MoveAndRotate()
  {
    if (moveVertical != 0)
    {
      myBody.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
    }

    rotY += moveHorizontal * rotationSpeed;

    myBody.rotation = Quaternion.Euler(0f, rotY, 0f);
  }

  void AnimatePlayer()
  {
    if (moveVertical != 0)
    {
      if (!isPlayerMoving)
      {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_RUNNING_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_RUNNING_ANIMATION))
        {
          isPlayerMoving = true;

          anim.SetTrigger(MyTags.RUN_TRIGGER);
        }
      }
    }
    else
    {
      if (isPlayerMoving)
      {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_RUNNING_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_RUNNING_ANIMATION))
        {
          isPlayerMoving = false;
          anim.SetTrigger(MyTags.STOP_TRIGGER);
        }
      }
    }
  }

  void Attack()
  {
    if (Input.GetKeyDown(KeyCode.LeftControl))
    {
      if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION) || !anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_ANIMATION))
      {
        if (!isPlayerMoving)
        {
          anim.SetTrigger(MyTags.ATTACK_1_TRIGGER);
        } 
        else {
          anim.SetTrigger(MyTags.ATTACK_1_RUNNING_TRIGGER);
        }
      }
    }
    else if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION) || !anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_ANIMATION))
      {
        if (!isPlayerMoving)
        {
          anim.SetTrigger(MyTags.ATTACK_2_TRIGGER);
        }
        else {
          anim.SetTrigger(MyTags.ATTACK_2_RUNNING_TRIGGER);
        }
      }
    }
  }

  void Defend() {
    if (Input.GetKeyDown(KeyCode.Z)) {
      if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_1_RUNNING_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_2_RUNNING_ANIMATION)) {
        
        anim.SetTrigger(MyTags.STOP_TRIGGER);
      }

      isDefending = true;
      anim.SetTrigger(MyTags.DEFEND_TRIGGER);
    }

    if (Input.GetKeyUp(KeyCode.Z)) {

      isDefending = false;
      anim.SetTrigger(MyTags.STOP_DEFEND_TRIGGER);
    }
  }

  void ActivateDamagePoint() {
      damagePoint.SetActive(true);
  }

  void DeactivateDamagePoint() {
      damagePoint.SetActive(false);
  }
}
