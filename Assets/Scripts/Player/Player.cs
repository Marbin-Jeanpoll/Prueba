using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector2 inputMov;
    Vector2 inputRot;

    public float sensibilidad;
    Transform cam;
    float rotX;
    public float velocidad = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
        rotX = cam.localEulerAngles.x;
    }
    void Update()
    {
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRot.x = Input.GetAxis("Mouse X") * sensibilidad;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibilidad;
    }

    private void FixedUpdate()
    {
        float vel = velocidad;
        rb.velocity = transform.forward * vel * inputMov.y
                      + transform.right * vel * inputMov.x
                      + new Vector3(0,rb.velocity.y,0);

        transform.rotation *= Quaternion.Euler(0,inputRot.x,0);

        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -50, 50);
        cam.localRotation = Quaternion.Euler(rotX,0,0);
    }
}
