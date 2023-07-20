using UnityEngine;
using UnityEngine.SceneManagement;

public class backGame : MonoBehaviour
{
    private string previousSceneName;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
                LoadTargetScene();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        previousSceneName = SceneManager.GetActiveScene().name;
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(previousSceneName);
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene("escMenu");
    }
}
