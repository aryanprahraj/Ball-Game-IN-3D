using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenController : MonoBehaviour
{
    void Update()
    {
        // Press Space or Enter to go back to Main Menu
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
