using UnityEngine;


// <summary>
// Script simples de lanterna para jogo 3D de terror.
// Liga e desliga com o botão direito do mouse.
// Basta ter um componente Light (Spot ou Point) no objeto ou como filho.
// </summary>
public class Lanterna : MonoBehaviour
{
    [Tooltip("Arraste aqui o componente Light (Spot) da lanterna")]
    public Light lightSource;


    private bool isOn = false;


    void Start()
    {
        if (lightSource == null)
            lightSource = GetComponentInChildren<Light>();


        if (lightSource != null)
            lightSource.enabled = false; // Começa desligada
    }


    void Update()
    {
        // Clique com o botão direito (1) liga/desliga
        if (Input.GetMouseButtonDown(1))
        {
            isOn = !isOn;
            if (lightSource != null)
                lightSource.enabled = isOn;
        }
    }
}