using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// coments genrated only for this code by copilot
public class Timer : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component for displaying the timer
    [SerializeField] TextMeshProUGUI timerText;
    // The amount of time remaining (in seconds)
    [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        // Decrease the remaining time by the time elapsed since last frame
        remainingTime -= Time.deltaTime;

        // Calculate minutes and seconds from the remaining time
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Update the timer text in MM:SS format
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // If time runs out, reload the first scene (scene index 0)
        if (remainingTime <= 1 || Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
