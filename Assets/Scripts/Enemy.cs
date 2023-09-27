using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [Header ("Patrol Points")]
    [SerializeField]private Transform leftEdge;
    [SerializeField]private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    private void Update(){
        MoveInDirection(1);
    }

    private void MoveInDirection(int _direction){
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime *_direction*speed,enemy.position.y,enemy.position.z);
    }
}
