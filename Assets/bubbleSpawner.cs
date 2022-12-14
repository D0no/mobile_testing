using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleSpawner : MonoBehaviour
{
    public GameObject bubble_prefab;
    public List<Transform> positions;
    public List<GameObject> bubbles;
    public float lifetime;

    public int bubble_count = 0;
    public int max_bubbles;
    private int current_index;
    public GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Instantiate(bubble_prefab, initial_position);
       /*current_index = Random.Range(0, bubbles.Count);
       if (bubble_count < max_bubbles)
        {
            //Instantiate(bubble_prefab, positions[Random.Range(0, positions.Count)].position, Quaternion.LookRotation(screen.transform.up));
            bubbles.Add(Instantiate(bubble_prefab, positions[current_index].position, Quaternion.LookRotation(screen.transform.up)));
            bubble_count++;
        }*/
         
    }
    private void Spawn()
    {
        var bubble = Instantiate(bubble_prefab, positions[Random.Range(0, positions.Count)].position, Quaternion.LookRotation(screen.transform.up));
        Destroy(bubble, lifetime);
    }

}

