using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Name of the gameplay scene
    public string gameSceneName = "Game";

    void Update()
    {
        // When SPACE is pressed, I made sure it loads the game scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
