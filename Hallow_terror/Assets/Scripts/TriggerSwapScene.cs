using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSwapScene : MonoBehaviour
{
    public string Scenename;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scenename);
        }
    }
}
