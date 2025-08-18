using UnityEngine;


public class SettingsMenu : MonoBehaviour
{
    //Staic varibales for target settings to be passed between scenes
    public static float SpeedValue;
    public static float TargetDistance;
    public static bool TargetMoving;
    public static int TargetCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Each function sets the variable to the result from settings menu
    public void SetSpeed(float speed)
    {
        SettingsMenu.SpeedValue = speed;
        Debug.Log(SpeedValue);
    }
    public void SetDistance(float distance)
    {
        TargetDistance = distance;
    }

    public void SetMoving(bool moving)
    {
        TargetMoving = moving;
    }

    public void SetTargetCount(int count)
    {
        TargetCount = count;
    }
}
