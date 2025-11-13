using UnityEngine;

public class CutsceneStart : MonoBehaviour
{
    public GameObject cutscene;
    private void OnTriggerEnter(Collider other)
    {

       
       if(other.gameObject.CompareTag("Player"))
        {
            cutscene.SetActive(true);
        }
    }
}
