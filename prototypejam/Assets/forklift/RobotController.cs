using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        liftMin = lift.localPosition.y;
        //GetComponent<Rigidbody>().centerOfMass = CenterOFMass.position;
    }
    public Transform lift;
    public Vector2 controllers;
    public bool first;
    public bool second;
    public bool third;


    void getInput()
    {

        /*  if (Input.GetKey(KeyCode.LeftArrow))
          {
              controllers.x = -1;
          }
          else if (Input.GetKey(KeyCode.RightArrow))
          {
              controllers.x = 1;
          }
          else
          {
              controllers.x = 0;
          }

          if (Input.GetKey(KeyCode.UpArrow))
          {
              controllers.y = 1;
          }
          else if (Input.GetKey(KeyCode.DownArrow))
          {
              controllers.y = -1;
          }
          else
          {
              controllers.y = 0;
          }
          first = Input.GetKey(KeyCode.Z);
          second = Input.GetKey(KeyCode.X);
          third = Input.GetKey(KeyCode.Space);*/
        controllers.x = Input.GetAxis("Horizontal");
        controllers.y = Input.GetAxis("Vertical");
        first = Input.GetButton("Fire1");
        second = Input.GetButton("Jump");
        third = Input.GetButton("Cancel");
    }
    public float liftMax;
    float liftMin;
    public Transform CenterOFMass;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 10, 0);
        }
        getInput();
        transform.Translate(0, 0, controllers.y*Time.deltaTime*8);
        transform.Rotate(0, controllers.x * Time.deltaTime * 30, 0);


        if (first && lift.localPosition.y < liftMax)
        {
            lift.localPosition += (Vector3.up * Time.deltaTime);
        }
        if (second && lift.localPosition.y > liftMin)
        {
            lift.localPosition+=(Vector3.down * Time.deltaTime);
        }

    }
}
