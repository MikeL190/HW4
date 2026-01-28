using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Manager : MonoBehaviour
{
    [SerializeField] private GameObject pipeSpawner;
    [SerializeField] private GameObject pipePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Spawn_Pipe();
    }

    public void Spawn_Pipe()
    {
        Instantiate(pipePrefab, pipeSpawner.transform.position, Quaternion.identity);
    }
}
