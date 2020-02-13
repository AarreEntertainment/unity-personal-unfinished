using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{

    public Vector3 frwheelInitRot;
    // Start is called before the first frame update
    void Start()
    {
        frwheelInitRot = frwheels[0].forward;
    }
    public Transform[] wheels;
    public Transform[] frwheels;
    public float speed;
    public float rotation;
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform wheel in frwheels)
        {
            wheel.localEulerAngles = new Vector3(0, Input.GetAxis("Horizontal") * 45, 0);
         }

        GetComponent<Rigidbody>().AddForce(transform.forward * Input.GetAxis("Vertical")*speed, ForceMode.Acceleration);
        GetComponent<Rigidbody>().AddTorque(transform.up * Input.GetAxis("Horizontal") * rotation, ForceMode.VelocityChange);
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(Vector3.right*GetComponent<Rigidbody>().velocity.magnitude* Input.GetAxis("Vertical"));
        }
        GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * GetComponent<Rigidbody>().angularVelocity.y);
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 10, 0);
        }
    }
    
}
