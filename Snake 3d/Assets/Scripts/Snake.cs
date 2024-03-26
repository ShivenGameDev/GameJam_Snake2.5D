

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Snake : MonoBehaviour
{
    private Vector3 _direction = Vector3.up;
    private List<Transform> _segments;
    public Transform BodyPrefab;
    public int deaths=0;
    public Text coinCollected;
    public int coins=0;
    public Text lives;
    public float speed=5f;

    private void Start(){
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        
        StartCoroutine(WaitForFunction());
    }
    IEnumerator WaitForFunction()
{
    yield return new WaitForSeconds(3);
    Debug.Log("Hello!");  
}
    private void Update(){
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _direction!=Vector3.down){
            _direction=Vector3.up;
        }
        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))&& _direction!=Vector3.right){
            _direction=Vector3.left;
        }
        if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))&& _direction!=Vector3.left){
            _direction=Vector3.right;
        }
        if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))&& _direction!=Vector3.up){
            _direction=Vector3.down;
        }
        //Debug.Log("Coins : %d",coinCollected);
        Debug.Log(deaths);
        
    }
    private void FixedUpdate(){
        for(int i=_segments.Count-1;i>0;i--){
            _segments[i].position=_segments[i-1].position;
        }

        this.transform.position = new Vector3(
            this.transform.position.x + (_direction.x*speed*Time.deltaTime),
            this.transform.position.y,
            this.transform.position.z + (_direction.y*speed*Time.deltaTime)
        );
        coinCollected.text=coins.ToString();
        switch(deaths){
        default:
        case 0: lives.text="3";break;
        case 1: lives.text="2";break;
        case 2: lives.text="1";break;}
    }

    public void ResetState(){
        for(int i=1;i<_segments.Count;i++){
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }

    private void Grow(){
        Transform body = Instantiate(this.BodyPrefab);
        body.position = _segments[_segments.Count-1].position;
        _segments.Add(body);
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag=="Coin"){
            Grow();
            coins++;
        }
        else if(other.tag=="Obstacle"){
            ResetState();
            deaths++;
            if(deaths==3){
                SceneManager.LoadSceneAsync(3);
            }
        }
    }


}
