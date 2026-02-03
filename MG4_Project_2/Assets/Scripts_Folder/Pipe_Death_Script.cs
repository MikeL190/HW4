using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Death_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string currentTag = collision.gameObject.tag;
        switch (currentTag)
        {
            case "Pipe Top":
            case "Pipe Bottom":
                Destroy(collision.gameObject.transform.parent.gameObject);
                break;
        }
    }

}
