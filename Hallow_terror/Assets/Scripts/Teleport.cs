using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Teleport_caveOut;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = Teleport_caveOut.transform.position;
        }
    }
}
