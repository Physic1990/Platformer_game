using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    public float Threashold;
    private bool grounded = true;
    private Vector3 SpawnPosition;
    private void Awake(){
        body = GetComponent<Rigidbody2D>();
    }
    void Start(){
        SpawnPosition = this.transform.position;
        //Debug.Log(SpawnPosition);
    }
    // Update is called once per frame
    private void Update(){
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,body.velocity.y);
        if(Input.GetKey(KeyCode.Space)&& grounded){
            Jump();
        }
        if(transform.position.y<Threashold){
            
            Reset();
        }
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x,speed);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true; 
        }
    }
    public void Reset(){
        this.transform.position = SpawnPosition;
    }

}
