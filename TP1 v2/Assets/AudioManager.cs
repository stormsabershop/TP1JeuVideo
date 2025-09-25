using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip backgroundMusic;
    public AudioClip gameOverMusic;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 1f;
        musicSource.Play();
    }

    void Update()
    {
        if (playerController.gameOver && musicSource.clip != gameOverMusic)
        {
            musicSource.Stop();
            musicSource.clip = gameOverMusic;
            musicSource.loop = false;
            musicSource.volume = 0.5f;
            musicSource.Play();
        }
    }
}
