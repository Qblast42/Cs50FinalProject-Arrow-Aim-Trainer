using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class TargetController : MonoBehaviour
{
    public GameObject Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float targetSpeed;
    // Controls movement speed

    public bool moving;
    // Set if targets moves

    public Transform Endpoint;


    void Start()
    {
        // On start creates randomly genrated target point and assigns speed 
        Endpoint.position = TargetBounds.Instance.GetRandomPosition();
        targetSpeed = SettingsMenu.SpeedValue;
        Debug.Log(targetSpeed);
        moving = SettingsMenu.TargetMoving;
        Debug.Log(moving);
    }

    //Every frame if moving, moves target towards its endpoint
    void Update()
    {
        if (moving == true)
        {
            var step = targetSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Endpoint.position, step);
            if (Vector3.Distance(transform.position, Endpoint.position) < 0.001f)
            {
                Endpoint.position = TargetBounds.Instance.GetRandomPosition();
            }
        }
    }
    //Detecs collison, if so desotrys the arrow and relocates target randomly and adds score + 1 and calcs accuracy
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            Debug.Log("CollsionDetected");
            ScoreController.Instance.CalcAccuracy("hit");
            transform.position = TargetBounds.Instance.GetRandomPosition();
            Destroy(collision.gameObject);
            ScoreController.Instance.AddScore();
        }
    }
}
//Used copilot to debugg error occuring from spacing of {}'s