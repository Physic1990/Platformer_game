using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    [SerializeField] private int extraJumps;
    private int jumpCounter; 
    [SerializeField]private float speed;
    private Rigidbody2D body;
    public float Threashold;
    private bool grounded = true;
    private Vector3 SpawnPosition;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component

        
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
        }else if(!grounded&&jumpCounter>0&&(Input.GetKey(KeyCode.Space))){
            Jump();
        }
        if(transform.position.y<Threashold){
            
            Reset();
        }
    }

private void Jump(){
    body.velocity = new Vector2(body.velocity.x, speed);
    grounded = false;

    // Play the jump sound
    if (jumpSound != null)
    {
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }
}

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true; 
            jumpCounter = extraJumps;
        }
    }
    public void Reset(){
        this.transform.position = SpawnPosition;
    }
    

}
