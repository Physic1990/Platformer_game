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
    public TextMeshPro Wintext;
    public static bool GameIsPaused = false;
    public void LevelFinish(){
        //Debug.Log("Player Won");
        Wintext.enabled = true; 
    }
    private void Start(){
        Wintext.enabled = false;
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
    void Update(){
        if(Wintext.enabled){
            Pause();
        }
    }
    void Resume(){
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(){
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
