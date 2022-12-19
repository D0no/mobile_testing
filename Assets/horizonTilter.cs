using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizonTilter : MonoBehaviour
{
    [SerializeField] private accelInfo _accelinfo;
    [SerializeField] public float attenuation = 0.01f;
    public GameObject screen;
    public GameObject horizon;
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
        //adjust rotation to acceleration (needs interpolation)
    }
}
