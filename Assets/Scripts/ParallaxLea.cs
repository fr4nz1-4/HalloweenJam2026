using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLea : MonoBehaviour
{
    private float length, startpos;
    // public GameObject cam;
    public float parallaxEffect;
    public float speed;
    public bool parallaxPause;
    
    // Start is called before the first frame update
    void Start()
    {
        // startpos = gameObject.transform.position.x;
        
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    { // Move Background in different pace -> parallax effect
        // float dist = cam.transform.position.x * parallaxEffect;
        // gameObject.transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (parallaxPause == false)
        {
            gameObject.transform.position += new Vector3((speed +6)* Time.deltaTime * parallaxEffect, 0, 0);
        }

    }
}