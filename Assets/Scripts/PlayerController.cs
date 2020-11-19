using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick movement;
    public Joystick action;
    public Rigidbody2D playerRB;
    private float moveSpeed = 5f;
    private float horizontalMove = 0f;
    private float veritcalMove = 0f;
    public Animator playerAnim;
    
    void Update()
    {
        horizontalMove = movement.Horizontal;
        veritcalMove = movement.Vertical;

        playerRB.velocity = new Vector2(horizontalMove,veritcalMove) * moveSpeed;
        Vector2 actionVector = new Vector2(action.Horizontal,action.Vertical);
        if(actionVector == Vector2.zero) {
            playerAnim.SetFloat("moveX", playerRB.velocity.x);
            playerAnim.SetFloat("moveY", playerRB.velocity.y);
        } else {
            playerAnim.SetFloat("moveX", actionVector.x);
            playerAnim.SetFloat("moveY", actionVector.y);
        }
        
    }
}
