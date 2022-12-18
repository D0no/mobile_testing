using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelResponse : MonoBehaviour
{
    [SerializeField] private accelInfo _accelinfo;
    [SerializeField] public float attenuation = 0.01f;

    //need to map the forces on these two axis
    Vector3 planeUp;
    Vector3 planeRight;

    //values for the acceleration module on the two world axis
    float accel_z;
    float accel_x;

    //forces to apply
    Vector3 upAccel;
    Vector3 rightAccel;

    Vector3 plane_normal;
    Vector2 upDirProjected;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        planeUp = screen.transform.forward.normalized;
        Debug.DrawRay(screen.transform.position, planeUp, Color.red, 500);

        planeRight = screen.transform.right.normalized;
        Debug.DrawRay(screen.transform.position, planeRight, Color.red, 500);

        this.GetComponent<Rigidbody>().AddForce(-planeUp * _accelinfo.acceleration.z * attenuation);
        this.GetComponent<Rigidbody>().AddForce(-planeRight * _accelinfo.acceleration.x * attenuation);


        //accel_x = _accelinfo.acceleration.x;
        //accel_z = _accelinfo.acceleration.z;

        //upAccel = planeUp * accel_z;
        //rightAccel = planeRight * accel_x;


        //this.GetComponent<Rigidbody>().AddForce(-upAccel * attenuation);
        //this.GetComponent<Rigidbody>().AddForce(-rightAccel * attenuation);


        /*plane_normal = Vector3.Cross(Vector3.Cross(screen.transform.forward, screen.transform.up), screen.transform.forward);
        Debug.DrawRay(screen.transform.position, plane_normal, Color.green, 500);
        upDir = Vector3.ProjectOnPlane(_accelinfo.acceleration, plane_normal);*/


        // move by appliying force to rigidbody2D component
        //this.GetComponent<Rigidbody2D>().AddRelativeForce(-(new Vector2(_accelinfo.acceleration.x, _accelinfo.acceleration.y)*attenuation));
        //this.GetComponent<Rigidbody2D>().AddRelativeForce(-upDir*attenuation);
        //move with transform translation


    }
}
