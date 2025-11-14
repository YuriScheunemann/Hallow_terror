using UnityEngine;
using TMPro;
public class Quests : MonoBehaviour
{
    public CutsceneStart cutsceneStart;
    public int[] questCont;
    string[] queststxt;
    [SerializeField]
    TMP_Text questAtual;
    public int indexQuest = 0;
    void Start()
    {       
       queststxt = new string[5];
       queststxt[0] = "Encontrar lanterna";
       queststxt[1] = "Voltar para a vila";

       questAtual.text = queststxt[indexQuest];
    }


void Update()
    {
       
    }

    public void NextQuest()
    {
        indexQuest++;

        if (indexQuest >= queststxt.Length)
            return;

        questAtual.text = queststxt[indexQuest];
    }
}
