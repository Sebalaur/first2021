using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameObject collectible;
    private bool focus = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStart(){
        focus = true;
        StartCoroutine(Loading());
    }
    IEnumerator Loading(){
        while(true){
            yield return new WaitForSeconds(1f);
            LoadingDone();
        }

    }
    void LoadingDone(){
        if(focus){
            Destroy(collectible);
            StopAllCoroutines();
        }
    }
    public void LoadStop(){
        focus = false;
        StopAllCoroutines();
    }
}
