using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip coinSound;

    public static Audio_Manager Instance { get; private set; }
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

        User_Player.Pass_Obstacle_Event += Play_Coin_Sound;
        User_Player.Collide_Obstacle_Event += Play_GameOver_Sound;
        User_Player.Jump_Event += Play_Jump_Sound;
    }

    public void Play_Coin_Sound()
    {
        myAudioSource.PlayOneShot(coinSound);
    }

    public void Play_GameOver_Sound()
    {
        myAudioSource.PlayOneShot(gameOverSound);
    }

    public void Play_Jump_Sound()
    {
        myAudioSource.PlayOneShot(jumpSound);
    }
}
