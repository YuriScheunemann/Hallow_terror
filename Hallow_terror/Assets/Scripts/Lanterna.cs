using UnityEngine;

public class Lanterna : MonoBehaviour
{
   
    public Light lanternaLight;

    void Start()
    {
        
        if (lanternaLight != null)
            lanternaLight.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lanternaLight != null)
                lanternaLight.enabled = !lanternaLight.enabled;
        }
    }
}