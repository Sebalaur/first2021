using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float speed = 25.0f;
	public float jumpForce = 300.0f;

	private float levelnum = 1;

	private float bestlevelnum = 1;

	public Text level;

	public Text bestlevel;

	private bool canJump = true;
	
	void Update () {
		transform.Translate(0, 0, speed * Time.deltaTime);

		if (Input.GetMouseButtonDown(0) && canJump) {
			canJump = false;
			this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
		}

		if (Input.GetKey("a")) {
			transform.Translate(-7*Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("d")) {
			transform.Translate(7*Time.deltaTime, 0, 0);
		}

		if (transform.position.y < -25) {
			this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
			transform.position = new Vector3(0, 2, 1);
			levelnum = 1;
			speed = 25;
			level.text = "Level: " + levelnum;
		}

		transform.Translate(Input.acceleration.x, 0, 0);
	}

	void OnCollisionEnter(Collision collision) {
		canJump = true;
		if (collision.gameObject.tag == "Obstacle") {
			transform.position = new Vector3(0, 2, 1);
			levelnum = 1;
			speed = 25;
			level.text = "Level: " + levelnum;
		} if (collision.gameObject.tag == "Fin") {
			transform.position = new Vector3(0, 2, 1);
			speed += 5;
			levelnum += 1;
			if(levelnum > bestlevelnum){
				bestlevelnum += 1;
			}
			bestlevel.text = "Best Level: " + bestlevelnum;
			level.text = "Level: " + levelnum;
		}
	}
}
