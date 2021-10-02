using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        playerPos.Translate(new Vector3(xMove * Time.deltaTime * speed, yMove * Time.deltaTime * speed));
    }
}
