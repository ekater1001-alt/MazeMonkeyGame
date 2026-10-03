using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalbananas = 10;
    public int bananasCollected = 0;

    public Text bananaText;
    public int lives = 3;
    public Text livesText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void Collectbanana()
    {
        bananasCollected++;
        UpdateUI();
    }
    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            RestartGame();
        }
    }

    void UpdateUI()
    {
        if (bananaText != null)
            bananaText.text = "Бананы: " + bananasCollected + " / " + totalbananas;
        if (livesText != null)
            livesText.text = "Жизни: " + lives;
    }

    public void WinGame()
    {

        if (GameUI.Instance != null)
            GameUI.Instance.ShowWinScreen();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}