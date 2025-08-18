using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject arrow;
    // New arrowHolder object
    public GameObject arrowHolder; // Added this line
    //arrow stats
    public float shootForce = 75f;
    //bow stats
    public float shootdelay = 0.7f;
    //bools for checks
    public bool isShooting, readyToShoot, allowInvoke;

    //reference
    public Transform attackPoint;
    public Camera MainCamera;

    //Sets boolm variables to proper states on game start
    private void Awake()
    {
        isShooting = false;
        readyToShoot = true;
        allowInvoke = true;
        Debug.Log("ArrowBehavior On");
    }


    private void Update()
    {
        myInput();
    }

    //Deetcs mouse press to start shoot func
    private void myInput()
    {
        isShooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (isShooting && readyToShoot)
        {
            shoot();
        }
    }

    private void shoot()
    {
        readyToShoot = false;
        // find arrow target with raycast
        Ray ray = MainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //check for raycast hit
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //if aiming at the sky
        //calc direction from attack point
        Vector3 direction = targetPoint - attackPoint.position;

        //Create the arrow to be fired
        // Changed 'arrow' to 'arrowHolder' as requested
        GameObject firedArrow = Instantiate(arrowHolder, attackPoint.position, Quaternion.identity);
        firedArrow.GetComponent<Rigidbody>().isKinematic = false;
        firedArrow.GetComponent<Rigidbody>().useGravity = true;
        firedArrow.transform.forward = direction.normalized;
        //apply forces to the arrow

        firedArrow.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        
        ScoreController.Instance.CalcAccuracy("fired");

        //Invoke func to reset shot
        if (allowInvoke)
        {
            Invoke("ResetShot", shootdelay);
            allowInvoke = false;
        }

        // Destroy the arrow after 5 seconds directly from shoot()
        Destroy(firedArrow, 5f);
        //Use gathered from  copilot
    }

    //Reset shots to allow arrow to be fired after delay
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}
