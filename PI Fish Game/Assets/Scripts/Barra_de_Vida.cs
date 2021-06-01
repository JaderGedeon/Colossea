using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_de_Vida : MonoBehaviour
{

    private RectTransform rectTransform;

    public bool boss = false;

    public Image barra_de_vida;

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void Update_Barra_de_Vida(float fracao)
    {
        if (!boss)
            barra_de_vida.fillAmount = fracao;
        else {
            Debug.LogError("FOI AQUI");
            rectTransform.localScale = new Vector3(fracao, 1.15f, 0);
        }
    }
}
