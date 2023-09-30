using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public GameObject player;
    public float distance; 

    [Header ("Patrol Points")]
    [SerializeField]private Transform leftEdge;
    [SerializeField]private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]
    [SerializeField]private float idleDuration;
    private float idleTimer;

    private void Awake(){
        initScale = enemy.localScale;
    }

    private void Update(){
        distance = Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if(distance<10){
            transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position, speed*Time.deltaTime);
        }
        if(movingLeft){
            if(enemy.position.x >= leftEdge.position.x){
                MoveInDirection(-1);
            }else{
                DirectionChange();
            }
        }else{
            if(enemy.position.x <= rightEdge.position.x){
                MoveInDirection(1);
            }else{
                DirectionChange();
            }
        }
    }

    private void DirectionChange(){

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration){
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction){
        idleTimer=0;

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x)*_direction,initScale.y,initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime *_direction*speed,enemy.position.y,enemy.position.z);
    }
}
