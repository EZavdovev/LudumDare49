using System;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Game.Audio;

public class PlayerMove : MonoBehaviour
{

    public static event Action OnPlayFootstepsEvent = delegate { };
    public static event Action OnStopPlatingFootstepsEvent = delegate { };

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

    private bool isPaused = false;

    private void Awake()
    {
        SoundManager.instance.StartPlayingEngines();
    }

    private void FixedUpdate()
    {
        if (isPaused)
        {
            return;
        }
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
            OnStopPlatingFootstepsEvent();
        }

        if (xMove > 0 && animator.runtimeAnimatorController != animations[1])
        {
            animator.runtimeAnimatorController = animations[1];
            OnPlayFootstepsEvent();
        }

        if (xMove < 0 && animator.runtimeAnimatorController != animations[1])
        {
            animator.runtimeAnimatorController = animations[1];
            OnPlayFootstepsEvent();
        }

        if (xMove == 0 && yMove > 0 && animator.runtimeAnimatorController != animations[2])
        {
            animator.runtimeAnimatorController = animations[2];
            OnPlayFootstepsEvent();
        }

        if (xMove == 0 && yMove < 0 && animator.runtimeAnimatorController != animations[0])
        {
            animator.runtimeAnimatorController = animations[0];
            OnPlayFootstepsEvent();
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

    private void OnEnable()
    {
        GameScreenManager.OnStopGame += PauseMove;
    }

    private void OnDisable()
    {
        GameScreenManager.OnStopGame -= PauseMove;
    }

    private void PauseMove()
    {
        isPaused = true;
    }
}
