using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulator : MonoBehaviour
{

    public float max_speed = 20.0f;
    public float acceleration = 2.0f;
    public float rotationSensitivity = 3.0f;

    private float speed = 0f;
    private float curVertialSpeed = 0f;
    public float gravity = 9.8f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        //rotation updates
        {
            yaw += Input.GetAxis("Mouse X") * rotationSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * rotationSensitivity;

            transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -89f, 89f), yaw, 0); ;
        }
    }
}
