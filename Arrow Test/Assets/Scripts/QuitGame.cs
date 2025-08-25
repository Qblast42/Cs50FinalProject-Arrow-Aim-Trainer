using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // The method for your button
    public void Quit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    // A new method to test quitting with a key press
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting via Escape key.");
            Application.Quit();
        }
    }
}
