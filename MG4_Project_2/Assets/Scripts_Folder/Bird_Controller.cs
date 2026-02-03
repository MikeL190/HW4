using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour
{
    [SerializeField] private int jumpForce = 10;
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Pipe Top":
            case "Pipe Bottom":
                Debug.Log("Game Over");
                break;
            case "Ground":
                Debug.Log("You collided with the ground");
                break;
            default:
                Debug.Log("Tag not found so here is placeholder");
                break;
        }

        Debug.Log(collision.gameObject.tag);
    }

}
