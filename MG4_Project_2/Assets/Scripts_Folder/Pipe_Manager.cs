using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Manager : MonoBehaviour
{
    [SerializeField] private GameObject pipeSpawner;
    [SerializeField] private GameObject pipePrefab;

    private Dictionary<int, List<int> > myDictionary = new Dictionary<int, List<int> >()
    {
        { 0, new List<int> { 3, -1 } },
        { 1, new List<int> { 2, -2 } },
        { 2, new List<int> { 1, -3 } },
        { 3, new List<int> { 0, -4 } }
    };
    private Coroutine myRoutine;

    public static Pipe_Manager Instance { get; private set; }
    public Bird_Controller User_Player { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        User_Player = GameObject.FindWithTag("Player").GetComponent<Bird_Controller>();

        User_Player.Collide_Obstacle_Event += Death_Function;
        UI_Manager.Instance.Button_Event += Begin_Spawning_Loop;
        Begin_Spawning_Loop();
    }

    private void OnDisable()
    {
        User_Player.Collide_Obstacle_Event -= Death_Function;
        UI_Manager.Instance.Button_Event -= Begin_Spawning_Loop;
    }

    public void Death_Function()
    {
        StopCoroutine(myRoutine);

        int amountOfChildren = pipeSpawner.transform.childCount;
        for(int i = 0; i < amountOfChildren; i++)
        {
            pipeSpawner.transform.GetChild(i).GetComponent<Pipe_Controller>().enabled = false;
            pipeSpawner.transform.GetChild(i).GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            pipeSpawner.transform.GetChild(i).GetChild(2).GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Begin_Spawning_Loop()
    {
        int amountOfChildren = pipeSpawner.transform.childCount;
        for (int i = amountOfChildren - 1; i >= 0; i--)
        {
            Destroy(pipeSpawner.transform.GetChild(i).gameObject);
        }

        if (myRoutine != null)
        {
            StopCoroutine(myRoutine);
        }
        myRoutine = StartCoroutine(Spawn_Timer());
    }

    private IEnumerator Spawn_Timer()
    {
        while (true)
        {
            Spawn_Pipe();
            yield return new WaitForSeconds(3);
        }
    }

    private void Spawn_Pipe()
    {
        int randomIndex = Random.Range(0, 4);

        GameObject newPipe = Instantiate(pipePrefab, pipeSpawner.transform.position, Quaternion.identity, pipeSpawner.transform);
        newPipe.transform.GetChild(0).localPosition = new Vector3(0, myDictionary[randomIndex][0], 0);
        newPipe.transform.GetChild(2).localPosition = new Vector3(0, myDictionary[randomIndex][1], 0);
    }
}
