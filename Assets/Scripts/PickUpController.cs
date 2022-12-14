using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject heldobject;
    private Rigidbody heldobjectRB;
    [SerializeField] private Transform pickUpArea;
    [SerializeField] private float pickUpRange = 10f;
    [SerializeField] private float pickUpForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldobject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    //pick up
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                //drop
                DropObject();
            }
        }  
        if (heldobject != null)
        {
            //move
            MoveObject();
        }
    }

    void PickUpObject(GameObject pickobj)
    {
        if (pickobj.GetComponent<Rigidbody>())
        {
            heldobjectRB = pickobj.GetComponent<Rigidbody>();
            heldobjectRB.useGravity = false;
            heldobjectRB.drag = 10;
            heldobjectRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldobjectRB.transform.parent = pickUpArea;
            heldobject = pickobj;

        }
    }

    void DropObject()
    {
            heldobjectRB.useGravity = true;
            heldobjectRB.drag = 1;
            heldobjectRB.constraints = RigidbodyConstraints.None;

            heldobjectRB.transform.parent = null;
            heldobject = null;
    }

    void MoveObject()
    {
        /*if(Vector3.Distance(heldobject.transform.position, pickUpArea.position) < 0.1f)
        {
            Vector3 moveDirections = (pickUpArea.position - heldobject.transform.position);
            heldobjectRB.AddForce(moveDirections * pickUpForce, ForceMode.Acceleration);
        }*/
    }
}
