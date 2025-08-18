using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform CameraHolder;
    [SerializeField] float mouseSesitivity;
    float verticalLookRotation;
//Locks mouse cursor to crosshair on game start
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Every frame rotaes the camera reltive to mouse movement * sensitivty
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSesitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSesitivity;
        //Clamps value to prevent rotating past straight down/up
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        CameraHolder.localEulerAngles = new Vector3(-verticalLookRotation, 0f, 0f);

    }
}
