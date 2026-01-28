using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Controller : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.left * 5 * Time.deltaTime;
    }
}
