using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_Geral : MonoBehaviour
{
    public delegate void FimDaVidaDelegate();
    public FimDaVidaDelegate NofimDaVida;
    public delegate void FeedBack_Visual();
    public FimDaVidaDelegate FeedBack_Dano;
    public float totalVida;
    public float vidaCheia;

    private void Start()
    {
        vidaCheia = totalVida;
    }

    public void Dano(float total)
    {
        totalVida -= total;

        FeedBack_Dano();

        if (totalVida <= 0)
            NofimDaVida();

    }
}
