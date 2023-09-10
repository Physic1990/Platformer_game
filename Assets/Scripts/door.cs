using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            cam.MoveToNewRoom(nextRoom);
        }else{
            cam.MoveToNewRoom(previousRoom);
        }
    }
}
