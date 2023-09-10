using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour{
    public TextMeshPro Health;
    public float PlayerHealth = 3f;
    private float CurrentPlayerHealth;
    public EventTrigger.TriggerEvent DeathTrigger;

    private void Start(){
        CurrentPlayerHealth = PlayerHealth;
        Health.text = "Health: " + CurrentPlayerHealth;

    }
    public void PlayerDamaged(){
        CurrentPlayerHealth--;
        //Debug.Log(CurrentPlayerHealth);
        if(CurrentPlayerHealth<=0){
            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.DeathTrigger.Invoke(EventData);
            CurrentPlayerHealth = PlayerHealth;
        }
        Health.text = "Health: " + CurrentPlayerHealth;        
    }
}
