using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_de_Vida : MonoBehaviour
{

    public Image barra_de_vida;

    public void Update_Barra_de_Vida(float fracao)
    {
        barra_de_vida.fillAmount = fracao;
    }
}
