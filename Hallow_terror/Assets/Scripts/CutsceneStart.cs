using System;
using UnityEngine;
using UnityEngine.Events;
public class CutsceneStart : MonoBehaviour
{    
    public UnityEvent UnityEvent;
    public Quests Quests;
      
    private void OnTriggerEnter(Collider other)
    {       
       if(other.gameObject.CompareTag("Player"))
        {
            UnityEvent.Invoke();
            Quests.NextQuest();            
        }
    }
}
