using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelInfo : MonoBehaviour
{
    private Rigidbody rigidbody;

    public float magniude_threshold = 0.6f;
    public Vector3 lastposition;
    public Vector3 currentvelocity;
    public Vector3 lastvelocity;
    public Vector3 acceleration;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        currentvelocity = (transform.position - lastposition) / Time.deltaTime;
        if((currentvelocity - lastvelocity).magnitude <= magniude_threshold)
        {
            acceleration = Vector3.zero;
        }
        else
        {
            acceleration = (currentvelocity - lastvelocity) / Time.deltaTime;
        }
        

        lastvelocity = currentvelocity;
        lastposition = transform.position;
    }
}
