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

        //moving animation
        if(actionVector == Vector2.zero) {
            playerAnim.SetFloat("moveX", playerRB.velocity.x);
            playerAnim.SetFloat("moveY", playerRB.velocity.y);
        } else {
            playerAnim.SetFloat("moveX", actionVector.x);
            playerAnim.SetFloat("moveY", actionVector.y);
        }

        //idle animation
        if (horizontalMove > 0.1 || horizontalMove < -0.1 || veritcalMove > 0.1 || veritcalMove < -0.1) {
            if(action.Horizontal > 0.1 || action.Horizontal < -0.1 || action.Vertical > 0.1 || action.Vertical < -0.1) {
                playerAnim.SetFloat("lastX",action.Horizontal);
                playerAnim.SetFloat("lastY",action.Vertical);
            } else {
                playerAnim.SetFloat("lastX",horizontalMove);
                playerAnim.SetFloat("lastY",veritcalMove);
            }
        }

    }
}
