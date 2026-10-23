using UnityEngine;
using UnityEngine.InputSystem;

public class cameraScript : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
