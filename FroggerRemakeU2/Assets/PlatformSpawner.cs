using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject car1;
    public GameObject car2;

    public Vector3 carPos1 = new Vector3(31,25,95);
    public Vector3 carPos2 = new Vector3(64,25,4);

    private Vector3 platpos1 = new Vector3(45, 23, 5);
    private Vector3 platpos2 = new Vector3(55, 23, 95);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }
    IEnumerator Spawning(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3f,6f));

            if(Random.Range(0, 2)== 1)
            Instantiate(platform, platpos1, Quaternion.identity);
            if(Random.Range(0, 2)== 1)
            Instantiate(platform, platpos2, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            if(Random.Range(0, 2)== 1)
            Instantiate(car2, carPos2, Quaternion.identity);
            if(Random.Range(0, 2)== 1)
            Instantiate(car1, carPos1, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
