using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public float MoveSpeed = 5f;
    public float Distance = 2f;
    public Transform GroundDetect;

    private bool MovingRight = true;

    private void Update(){
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetect.position, Vector2.down, Distance);
        transform.Translate(Vector2.right*MoveSpeed * Time.deltaTime);
       
        if(groundInfo.collider==false){
            if(MovingRight == true){
                transform.eulerAngles = new Vector3(0,-180,0);
                MovingRight = false;
            }else{
                transform.eulerAngles = new Vector3(0,0,0);
                MovingRight = true;
            }
        }
    }
}
