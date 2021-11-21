using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
  private Rigidbody myBody;
  private Animator anim;
  public Transform groundCheck;
  public LayerMask groundLayer;
  bool isPlayerMoving;
  float playerSpeed = 0.05f;

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
    PlayerMoveKeyboard();
    AnimatePlayer();
  }

  void FixedUpdate()
  {
    MoveAndRotate();
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
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
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
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
        {
          isPlayerMoving = false;
          anim.SetTrigger(MyTags.STOP_TRIGGER);
        }
      }
    }
  }
}
