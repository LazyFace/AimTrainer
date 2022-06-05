using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private float sensivility = 100f;

    private float camRotation = 0f;

    [SerializeField] private GameObject player;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void Update(){

        float mouseX =  Input.GetAxis("Mouse X") * sensivility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivility * Time.deltaTime;

        camRotation -= mouseY;
        camRotation =  Mathf.Clamp(camRotation, -90f, 90f);

        player.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(camRotation, 0f, 0f);
        
    }
}
