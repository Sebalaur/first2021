using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform finishpoints;

    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 5.5f)
        SceneManager.LoadScene("SampleScene");

        if(finishpoints.childCount == 0)
        StartCoroutine(Restart());
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "platform")
        GetComponent<CharacterController>().Move(
            hit.transform.forward * (PlatformController.moveSpeed / 1.375f) * Time.deltaTime
        );
        if(hit.gameObject.tag == "car")
        SceneManager.LoadScene("SampleScene");
        if(hit.gameObject.tag == "finish")
        {
            hit.gameObject.GetComponent<Renderer>().material.color = Color.red;
            transform.position = startPos;
        }
        
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene");
    }
}
