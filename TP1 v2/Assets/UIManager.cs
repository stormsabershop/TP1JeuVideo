using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text scoreText;       // Texte du score
    public GameObject gameOverText;  // Objet UI "Game Over"

    private PlayerController playerController;
    private int score = 0;

    void Start()
    {
        gameOverText.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        UpdateScoreText();
    }

    void Update()
    {
        if (playerController.gameOver)
        {
            gameOverText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
