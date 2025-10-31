using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour
{
    public string sceneName;
   public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }
}
