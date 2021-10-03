using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private SpriteRenderer playerSee;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<RuntimeAnimatorController> animations = new List<RuntimeAnimatorController>();// 0 - walkdown 1 - wakside 2 - walkup 3 - idledown

    private bool isRight = false;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        RightMoveChange(xMove);
        playerPos.Translate(new Vector3(xMove * Time.deltaTime * speed, yMove * Time.deltaTime * speed));
        if (xMove == 0 && yMove == 0 && animator.runtimeAnimatorController != animations[3])
        {
            animator.runtimeAnimatorController = animations[3];
        }

        if (xMove > 0 && animator.runtimeAnimatorController != animations[1])
        {
            animator.runtimeAnimatorController = animations[1];
        }

        if (xMove < 0 && animator.runtimeAnimatorController != animations[1])
        {
            animator.runtimeAnimatorController = animations[1];
        }

        if (xMove == 0 && yMove > 0 && animator.runtimeAnimatorController != animations[2])
        {
            animator.runtimeAnimatorController = animations[2];
        }

        if (xMove == 0 && yMove < 0 && animator.runtimeAnimatorController != animations[0])
        {
            animator.runtimeAnimatorController = animations[0];
        }
    }

    private void RightMoveChange(float xMove)
    {
        if(xMove > 0 && isRight == false)
        {
            isRight = true;
            playerSee.flipX = true;
            return;
        }
        if(xMove < 0 && isRight == true)
        {
            isRight = false;
            playerSee.flipX = false;
        }

    }
}
