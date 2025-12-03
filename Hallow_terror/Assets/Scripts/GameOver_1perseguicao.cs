using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_1perseguicao : MonoBehaviour
{
   public string Scene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scene);
        }
        

    }
}
