using UnityEngine;

public class Enemy_GoToArea : MonoBehaviour
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
            }
        }

      
        float distPlayer = Vector3.Distance(transform.position, player.position);
        if (distPlayer <= triggerDistance)
        {
            AtivarContatoComJogador();
        }
    }

    void MoverAte(Vector3 destino)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            moveSpeed * Time.deltaTime
        );

        Vector3 direcao = destino - transform.position;
        if (direcao != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10f * Time.deltaTime);
        }
    }

    void AtivarContatoComJogador()
    {
        Debug.Log("O inimigo encostou no jogador!");
        // Aqui você coloca o jumpscare futuramente
    }
}