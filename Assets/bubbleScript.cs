using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    public float lifetime;
    public bool original = false;
    public bubbleSpawner _bubbleSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        Debug.Log("bubble destroyed");
        //_bubbleSpawner.bubble_count--;
    }
}
