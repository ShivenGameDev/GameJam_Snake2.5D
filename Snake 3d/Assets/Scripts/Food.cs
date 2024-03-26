using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider gridArea;
    private void Start(){
        RandomizePosition();
    }
    private void RandomizePosition(){
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.z,bounds.max.z);
        this.transform.position = new Vector3(Mathf.Round(x),0.23f,Mathf.Round(y));
    }   

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Player")
            RandomizePosition();
            
    }
}
