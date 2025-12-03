using UnityEngine;
using TMPro;
public class Quests : MonoBehaviour
{   
    public int[] questCont;
    string[] queststxt;
    [SerializeField]
    TMP_Text questAtual;
    public int indexQuest = 0;
    void Start()
    {       
       queststxt = new string[7];
       queststxt[0] = "Objetivo: Encontrar lanterna";
       queststxt[1] = "Objetivo: Voltar para a vila";
       queststxt[2] = "Objetivo: Volte o mais rápido possível para a vila!";
       queststxt[3] = "Objetivo: Busque informações sobre os habitantes da vila";
       queststxt[4] = "Objetivo: Fuja imediatamente da vila!";
       queststxt[5] = "Objetivo: Verifique a casa isolada";
       queststxt[6] = "Objetivo: Encontre a cura";
       queststxt[7] = "Objetivo: Fuja do boss";     

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
