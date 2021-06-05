using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptPlayer : MonoBehaviour
{
    public float speed = 20.0f;
    public float jumpForce = 300.0f;
    private float levelnum = 1;
    private float bestLevelNum = 1;
    public Text level;
    public Text bestLevel;

    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, speed * Time.deltaTime);
        if(Input.GetMouseButtonDown(0) && canJump){
            canJump = false;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));
        }
        if(Input.GetKey("a")){
            transform.Translate(-5*Time.deltaTime,0,0);
        }
        if(Input.GetKey("d")){
            transform.Translate(5*Time.deltaTime,0,0);
        }
        if(transform.position.y < -25){
            transform.position = new Vector3(0,2,1);
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,500,0));
            levelnum =1;
            speed = 25;
            level.text = "Level: " + levelnum;
        }
        transform.Translate(Input.acceleration.x,0,0);
    }
    void OnCollisionEnter(Collision col){
        canJump = true;
        if(col.gameObject.tag =="Obstacle"){
           transform.position = new Vector3(0,2,1);
           levelnum = 1;
           speed = 25;
           level.text = "Level: " + levelnum;
        }
        if(col.gameObject.tag == "Finish"){
            transform.position = new Vector3(0,2,1);
            speed +=5;
            levelnum +=1;
            if(levelnum > bestLevelNum){
                bestLevelNum +=1;
            }
            bestLevel.text = "Best Level: " + bestLevelNum;
            level.text = "Level: " + levelnum;
        }
    }
}
