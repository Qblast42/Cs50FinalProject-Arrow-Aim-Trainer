using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    //Loads the arrow game on play button press

    public int PlayerHighscore;
    public TextMeshProUGUI highscoreText;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // Allows curosr to move after game ends
    public void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerHighscore = ScoreController.highscore;
        highscoreText.text = "Current Highscore: " + PlayerHighscore.ToString();
        // Ensure ScoreController.highscore is public static int highscore in ScoreController.cs
    }

    //Exits the game for exit button press
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
