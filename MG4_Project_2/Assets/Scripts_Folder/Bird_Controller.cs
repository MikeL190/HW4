using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour
{
    [SerializeField] private int jumpForce = 10;
    [SerializeField] private Rigidbody2D myRigidBody;

    private bool canJump = true;

    public delegate void Bird_Delegate();
    public event Bird_Delegate Pass_Obstacle_Event;
    public event Bird_Delegate Collide_Obstacle_Event;
    public event Bird_Delegate Jump_Event;

    void Start()
    {
        Collide_Obstacle_Event += Stop_Movement;
        UI_Manager.Instance.Button_Event += Start_Movement;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            Jump_Event?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Pipe Top":
            case "Pipe Bottom":
                Collide_Obstacle_Event?.Invoke();
                break;
            case "Pipe Middle":
                Pass_Obstacle_Event?.Invoke();
                break;
        }
    }

    private void Stop_Movement()
    {
        canJump = false;
    }

    private void Start_Movement()
    {
        canJump = true;
    }

}
