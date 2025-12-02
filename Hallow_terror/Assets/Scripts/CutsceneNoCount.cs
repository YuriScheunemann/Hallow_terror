using UnityEngine;
using UnityEngine.Events;
public class CutsceneNoCount : MonoBehaviour
{
    public UnityEvent UnityEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnityEvent.Invoke();            
        }
    }
}
