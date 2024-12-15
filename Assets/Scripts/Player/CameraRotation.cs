using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotationInfo : MonoBehaviour
{

    //Data
    public float mouseSense = 2f;
    protected float yMaxAngle = 80f;
    protected float rotationX = .0f;
    protected float interactionDistance = 3f;

    //Physics
    protected Camera cam;
    public Player player;

    //Scripts
    public UIHelpSystem UI;

}

public class CameraRotation : CameraRotationInfo
{
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = GetComponent<Camera>();
        player = GetComponentInParent<Player>();


    }

    void Update()
    {
        Rotation();


        InteractWithObject();

        

    }


    void Rotation()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * mouseSense);

        rotationX -= mouseY * mouseSense;
        rotationX = Mathf.Clamp(rotationX, -yMaxAngle, yMaxAngle);
        transform.localRotation = Quaternion.Euler(rotationX, .0f, .0f);

    }




    private void InteractWithObject()
    {
        Ray ray = new Ray(cam.transform.position,cam.transform.forward);
  
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();


            if (interactable != null)
            {
                UI.actionHelp.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(player);
                }
            }



        }

        else
        {
            UI.actionHelp.enabled = false;
        }

    }




}
