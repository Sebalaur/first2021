using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;

    private bool canJump = false;

    private bool hasSwitchedLayers = false;

    private Vector3 startPos;

    void Start()
    {
        startPos = new Vector3(-10, 1.5f, 0);
    }
    void Update()
    {
        if (Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                -moveForce * Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
            );
        }
        if (Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                moveForce * Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
            );
        }
        if (Input.GetKeyDown("w") && canJump)
        {
            canJump = false;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
        if (Input.GetKeyDown("space"))
        {
            if (hasSwitchedLayers)
            {
                this.transform.position = new Vector3(
                    this.transform.position.x,
                    this.transform.position.y,
                    0
                );
            }
            else
            {
                this.transform.position = new Vector3(
                    this.transform.position.x,
                    this.transform.position.y,
                    10
                );
            }
            hasSwitchedLayers = !hasSwitchedLayers;
        }
        if (transform.position.y < -10)
        {
            this.transform.position = startPos;
            hasSwitchedLayers = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        if(collision.gameObject.name == "finish1"){
            this.transform.position = new Vector3(50, 1.5f, 0);
            hasSwitchedLayers = false;
        }
        if(collision.gameObject.tag == "obstacle"){
            this.transform.position = startPos;
            hasSwitchedLayers = false;
        }
        if(collision.gameObject.name == "trambulina"){
            GetComponent<Rigidbody>().AddForce(0,750,0);
        }
        if(collision.gameObject.name == "moneda"){
            Destroy(collision.gameObject);
            
        }
    }
    
}
