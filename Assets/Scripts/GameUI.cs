using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    [Header("UI Panels")]
    public GameObject menuPanel;    
    public GameObject winPanel;     
    public GameObject hudPanel;     
    public GameObject winCanvas;    

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ShowMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(1)
            && Cursor.lockState == CursorLockMode.None
            && menuPanel != null && !menuPanel.activeSelf
            && winCanvas != null && !winCanvas.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ShowMenu()
    {
        if (menuPanel != null) menuPanel.SetActive(true);
        if (winPanel != null) winPanel.SetActive(false);
        if (winCanvas != null) winCanvas.SetActive(false);
        if (hudPanel != null) hudPanel.SetActive(false);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        if (menuPanel != null) menuPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
        if (winCanvas != null) winCanvas.SetActive(false);
        if (hudPanel != null) hudPanel.SetActive(true);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowWinScreen()
    {
        if (winCanvas != null) winCanvas.SetActive(true);
        else if (winPanel != null) winPanel.SetActive(true);

        if (hudPanel != null) hudPanel.SetActive(false);
        if (menuPanel != null) menuPanel.SetActive(false);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}