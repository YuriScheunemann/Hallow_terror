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
       queststxt = new string[8];
       queststxt[0] = "Encontrar lanterna";
       queststxt[1] = "Voltar para a vila";
       queststxt[2] = "Volte o mais rápido possível para a vila!";
       queststxt[3] = "Busque informações sobre os habitantes da vila";
       queststxt[4] = "Fuja imediatamente da vila!";
       queststxt[5] = "Verifique a casa isolada";
       queststxt[6] = "Encontre a cura";
       queststxt[7] = "Fuja do boss";
       queststxt[8] = "Despeje a cura no rio";

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
