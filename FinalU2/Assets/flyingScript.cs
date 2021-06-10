using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingScript : MonoBehaviour
{
    public float baseSpeed;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = baseSpeed + GvrVRHelpers.GetHeadRotation().x *10;
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + GvrVRHelpers.GetHeadForward(),
            speed * Time.deltaTime
        );
    }
}
