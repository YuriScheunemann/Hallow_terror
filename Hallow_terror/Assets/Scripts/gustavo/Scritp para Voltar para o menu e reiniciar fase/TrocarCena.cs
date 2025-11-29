using UnityEngine;
using UnityEngine.SceneManagement; 

public class TrocarCena : MonoBehaviour
{
    public void QuitarParaOMenu()
    {
        
        SceneManager.LoadScene("Menu");
    }
}