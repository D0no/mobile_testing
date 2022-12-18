using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleSpawner : MonoBehaviour
{
    [SerializeField] private accelInfo _accelinfo;
    [SerializeField] public float attenuation = 0.01f;
    public GameObject bubble_prefab;
    public List<Transform> positions;
    public List<GameObject> bubbles;
    public float lifetime;

    public int bubble_count = 0;
    public int max_bubbles;
    private int current_index;
    public GameObject screen;

    Vector3 planeUp;
    Vector3 planeRight;

    //TIMER
    public float time_elapsed = 0;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6);
        for (bubble_count = 0; bubble_count < max_bubbles; bubble_count++)
        {
            Spawn();
        }

        bubble_count = max_bubbles;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        foreach(GameObject bubble in bubbles)
        {
            if(bubble == null)
            {
                bubbles.Remove(bubble);
            }
        }*/
        for (i = 0; i<bubbles.Count; i++)
        {
            if(bubbles[i] == null)
            {
                bubbles.RemoveAt(i);
            }
        }
        
    }

    private void FixedUpdate()
    {
        bubble_count = bubbles.Count;

        time_elapsed += Time.deltaTime;
        if (time_elapsed > 10)
        {
            //reset timer
            time_elapsed = 0;
            if(bubble_count < max_bubbles)
            {
                for(i=0; i<=max_bubbles-bubble_count; i++)
                {
                    Spawn();
                }
                bubble_count = max_bubbles;
            }
            
            
        }
        //apply forces
        planeUp = screen.transform.forward.normalized;
        Debug.DrawRay(screen.transform.position, planeUp, Color.red, 500);

        planeRight = screen.transform.right.normalized;
        Debug.DrawRay(screen.transform.position, planeRight, Color.green, 500);

        for (i = 0; i < bubbles.Count; i++)
        {
            if (bubbles[i] != null)
            {
                bubbles[i].GetComponent<Rigidbody>().AddForce(-planeUp * _accelinfo.acceleration.z * attenuation*Random.Range(0.5f, 1f));
                bubbles[i].GetComponent<Rigidbody>().AddForce(-planeRight * _accelinfo.acceleration.x * attenuation*Random.Range(0.5f, 1f));
            }
        }

        /*if(bubbles.Count > 0)
        {
            foreach (GameObject bubble in bubbles)
            {
                bubble.GetComponent<Rigidbody>().AddForce(-planeUp * _accelinfo.acceleration.z * attenuation);
                bubble.GetComponent<Rigidbody>().AddForce(-planeRight * _accelinfo.acceleration.x * attenuation);
            }
        }
       */


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
        //position is randomzed among the list of spawn points
        Debug.Log("bubble spawned");
        //randomize lifetime
        lifetime = Random.Range(5, 15);
        //randomize spawn position
        var bubble = Instantiate(bubble_prefab, positions[Random.Range(0, positions.Count)].position, Quaternion.LookRotation(screen.transform.up));
        
        //ranadomize scale
        bubble.transform.localScale = bubble.transform.localScale * Random.Range(1f, 2f);
        //randomize drag
        bubble.GetComponent<Rigidbody>().drag = Random.Range(0f, 0.5f);

        bubbles.Add(bubble);
        Destroy(bubble, lifetime);
    }
    
}

