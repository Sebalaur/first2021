using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public PlayerController playeer;
    public Camera gameCamera;

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(
            Mathf.Lerp(gameCamera.transform.position.x, playeer.transform.position.x, 0.03f),
            playeer.transform.position.y,
            Mathf.Lerp(gameCamera.transform.position.z, playeer.transform.position.z - 15, 0.03f)
        );
    }
}
