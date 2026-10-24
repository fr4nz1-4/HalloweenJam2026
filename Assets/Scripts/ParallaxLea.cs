using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLea : MonoBehaviour
{
    private float length, startpos;
    // public GameObject cam;
    public float parallaxEffect;
    public float speed = 3;
    
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
        gameObject.transform.position += new Vector3(speed * Time.deltaTime * parallaxEffect, 0, 0);

    }
}