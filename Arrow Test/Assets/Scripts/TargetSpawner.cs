using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Ints below control no. targets & there distance from the player
    public int TargetCount;
    public float Distance;
    public GameObject Target;

    public Transform TargetSystem;

    void Start()
    {
        Distance = SettingsMenu.TargetDistance;
        //Adds +1 to menu target count to account for 0 indexing
        if (SettingsMenu.TargetCount >= 0)
            TargetCount = SettingsMenu.TargetCount + 1;
        else
            TargetCount = 1;
            //Sets count to 1 in case of error
        Debug.Log(TargetCount);
        //Spawns set number of target (multiple ints in loop use reminded by gemeni)
        for (int i = 0, j = 0; i < TargetCount; i++, j += 2)
        {
            //Positions the spanwed target, distance controlls distance from player, and makes them active

            GameObject TargetClone = Instantiate(Target, new Vector3(-8 - Distance, 1f + j, 0f), Quaternion.Euler(0, 0, 0), TargetSystem) as GameObject;
            TargetClone.SetActive(true);
            //Setting clones as active helped by https://discussions.unity.com/t/instantiate-inactive-making-a-gameobject-active-instantiate/234229
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
