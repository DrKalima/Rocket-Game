using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float thrustPower = 20.0f;
    public float smooth = 5.0f;
    public float tiltAngle = 60.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    
    void Thrust()
    {
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") >= 0.0f)
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }               
    }

    void Rotate()
    {
        if (Input.GetButton("Horizontal"))
        {
            rb.freezeRotation = true;
            float horizontalInput = Input.GetAxis("Horizontal");

            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundZ = Input.GetAxis("Horizontal") * -tiltAngle;

            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            rb.freezeRotation = false;
        }
    }
    void Update()
    {
        Thrust();
        Rotate();
    }

}
