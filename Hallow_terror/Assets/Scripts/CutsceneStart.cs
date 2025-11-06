using UnityEngine;

public class CutsceneStart : MonoBehaviour
{
    public GameObject cutscene;
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            cutscene.SetActive(true);
        }
    }
}
