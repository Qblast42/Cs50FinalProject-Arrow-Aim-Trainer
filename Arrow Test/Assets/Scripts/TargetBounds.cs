using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance;

    public float distance;

    // Creates instace for script funcs to acessed in other scripts
    void Awake()
    {
        distance = SettingsMenu.TargetDistance;
        Instance = this;
    }

    [SerializeField] BoxCollider col;

    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;

        // Creates randomly generated variables for min/max values for targets to spawn
        float minY = center.y - col.size.y / 2f;
        float minZ = center.z - col.size.z / 2f;

        
        float maxY = center.y + col.size.y / 2f;
        float maxZ = center.z + col.size.z / 2f;

        
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        //generates random vector 3 postion from these random values & returns it

        Vector3 randomPosition = new Vector3(-8 - distance, randomY, randomZ);
        return randomPosition;
    }
}
