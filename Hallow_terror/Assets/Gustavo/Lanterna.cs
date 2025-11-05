using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public Light lanternaLight;

    public void Start()
    {
        // Garante que a lanterna comece desligada
        if (lanternaLight != null)
            lanternaLight.enabled = false;
    }

    public void Update()
    {
        // Ativa/desativa a lanterna ao pressionar 'F'
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lanternaLight != null)
                lanternaLight.enabled = !lanternaLight.enabled;
        }
    }
}