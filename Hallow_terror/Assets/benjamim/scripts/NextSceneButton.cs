using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
    public string nomeDaCena;

    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}