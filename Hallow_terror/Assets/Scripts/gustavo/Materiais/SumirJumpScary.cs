using UnityEngine;

public class SumirJumpScary : MonoBehaviour
{
    public GameObject jumpscareImage;
    public GameObject telaOpcoes;
    public float tempoParaSumir = 17.5f;

    void Start()
    {
        // deixa a tela de opções escondida
        telaOpcoes.SetActive(false);

        // chama a função depois de X segundos
        Invoke("SumirJumpscare", tempoParaSumir);
    }

    void SumirJumpscare()
    {
        jumpscareImage.SetActive(false); // some a imagem
        telaOpcoes.SetActive(true);      // aparece a tela com botões
    }
}