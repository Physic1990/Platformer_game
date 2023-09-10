using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger : MonoBehaviour{
    public EventTrigger.TriggerEvent FunctionActivate;
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.FunctionActivate.Invoke(EventData);
        }
    }
}
