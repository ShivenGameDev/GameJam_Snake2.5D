using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float trapTimer=0;
    private float trapTimerMax;
    public BoxCollider gridArea;
    public void Start(){
        RandomizePosition();
        trapTimerMax=2f;
    }

    public void Update(){
        trapTimer+=Time.deltaTime;
        if(trapTimer>=trapTimerMax){
            RandomizePosition();
            trapTimer=0f;
        }
    }
    public void RandomizePosition(){
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.z,bounds.max.z);
        this.transform.position = new Vector3(Mathf.Round(x),0.23f,Mathf.Round(y));
    }   
}
