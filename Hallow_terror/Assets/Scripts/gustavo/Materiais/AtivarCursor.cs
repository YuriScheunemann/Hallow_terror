using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class AtivarCursor : MonoBehaviour
{
    [Header("Configuração")]
    [Tooltip("Nome da cena que deve liberar o cursor (ex.: \"JumpScary\").")]
    [SerializeField] private string targetScene = "JumpScary";

    [Tooltip("Se verdadeiro, este GameObject será preservado entre cenas (DontDestroyOnLoad).")]
    [SerializeField] private bool persistAcrossScenes = true;

    void Awake()
    {
        if (persistAcrossScenes)
            DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        UpdateCursorForScene(SceneManager.GetActiveScene());
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    void OnActiveSceneChanged(Scene previous, Scene next)
    {
        if (!string.IsNullOrEmpty(targetScene) && previous.name == targetScene && next.name != targetScene)
        {
            LockCursor();
            return;
        }

        UpdateCursorForScene(next);
    }

 
    void OnSceneUnloaded(Scene scene)
    {
    
        if (!string.IsNullOrEmpty(targetScene) && scene.name == targetScene)
        {
            LockCursor();
        }
    }

    void UpdateCursorForScene(Scene scene)
    {
        if (!string.IsNullOrEmpty(targetScene) && scene.name == targetScene)
            UnlockCursor();
        else
            LockCursor();
    }

    void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}