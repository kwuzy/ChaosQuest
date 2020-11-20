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
    
    private void Start() {
        movement = GameObject.FindWithTag("Movement Joystick").GetComponent<FixedJoystick>();
        action = GameObject.FindWithTag("Action Joystick").GetComponent<FixedJoystick>();
    }
    
    void Update()
    {
        horizontalMove = movement.Horizontal;
        veritcalMove = movement.Vertical;

        playerRB.velocity = new Vector2(horizontalMove,veritcalMove) * moveSpeed;
        Vector2 actionVector = new Vector2(action.Horizontal,action.Vertical);

        //moving animation
        playerAnim.SetFloat("moveX", playerRB.velocity.x);
        playerAnim.SetFloat("moveY", playerRB.velocity.y);

        //action animation
        //when we have attack animations create new parameters in the animation file and change moveX and moveY to those
        playerAnim.SetFloat("actionX", actionVector.x);
        playerAnim.SetFloat("actionY", actionVector.y);
        
        //idle animation
        if (action.Horizontal > 0.1 || action.Horizontal < -0.1 || action.Vertical > 0.1 || action.Vertical < -0.1) {
            playerAnim.SetFloat("lastX",action.Horizontal);
            playerAnim.SetFloat("lastY",action.Vertical);
        } else if (horizontalMove > 0.1 || horizontalMove < -0.1 || veritcalMove > 0.1 || veritcalMove < -0.1) {
            playerAnim.SetFloat("lastX",horizontalMove);
            playerAnim.SetFloat("lastY",veritcalMove);
        }
    }
}
