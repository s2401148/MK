using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // Gắn GameOverUI parent

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false); // Ẩn lúc bắt đầu
    }

    // Gọi khi game kết thúc
    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f; // Tạm dừng game
        }
    }

    // Gọi khi nhấn Play Again
    public void PlayAgain()
    {
        Time.timeScale = 1f; // Bật lại game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Load lại scene hiện tại
    }

    // Gọi khi nhấn Exit
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Dừng play mode
#else
        Application.Quit(); // Thoát build game
#endif
    }
}
