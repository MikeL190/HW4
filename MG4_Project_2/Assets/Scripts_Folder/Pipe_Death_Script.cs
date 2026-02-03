using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Death_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Pipe Top":
            case "Pipe Bottom":
                Destroy(collision.gameObject.transform.parent.gameObject);
                Debug.Log("Deleted Pipe");
                break;
            case "Ground":
                Debug.Log("Pipe Death Script collided with the ground");
                break;
            default:
                Debug.Log("Pipe Death Script Tag not found so here is placeholder");
                break;
        }
    }
}
