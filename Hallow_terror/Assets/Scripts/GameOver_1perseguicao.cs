using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_1perseguicao : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("JumpScary");
        }
        

    }
}
