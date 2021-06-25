using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftControl : MonoBehaviour
{
    public float delta = 2.0f;
    public float speed = 2.0f;
    Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v.y = delta * Mathf.Sin(Time.time * speed);
        GetComponent<Rigidbody>().velocity = v;
    }
}
