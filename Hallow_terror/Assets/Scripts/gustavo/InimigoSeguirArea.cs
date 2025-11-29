using UnityEngine;
using UnityEngine.SceneManagement;

public class InimigoSegueArea : MonoBehaviour
{
    public Transform targetArea;
    public Transform player;
    public float moveSpeed = 3f;
    public float triggerDistance = 1.2f;

    private bool reachedArea = false;

    void Update()
    {
        if (!reachedArea)
        {
            MoverAte(targetArea.position);

            float distArea = Vector3.Distance(transform.position, targetArea.position);
            if (distArea <= 0.3f)
            {
                reachedArea = true;
                Debug.Log("Inimigo chegou na área!");
            }
        }

       
        float distPlayer = Vector3.Distance(transform.position, player.position);
        if (distPlayer <= triggerDistance)
        {
            CarregarCenaDeJumpScare();
        }
    }

    void MoverAte(Vector3 destino)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            moveSpeed * Time.deltaTime
        );
    }

    void CarregarCenaDeJumpScare()
    {
        SceneManager.LoadScene("JumpScary");
        
    }
}