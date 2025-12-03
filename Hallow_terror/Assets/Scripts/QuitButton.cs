using UnityEngine;

public class QuitButton : MonoBehaviour
{   
    public void QuitGame()
    {
       
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Sair do jogo no build
            Application.Quit();
#endif
    }
}
