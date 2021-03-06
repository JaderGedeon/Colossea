using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vida_Geral vida;
    public float dano;
    public float cadencia = 1f;
    public bool posso_dar_dano = true;

    public Barra_de_Vida barra_de_vida;

    //private Color feedBack_Cor;
    public Renderer mesh;
    public Material damageMaterial;
    private Material normalMaterial;

    private void Start()
    {

        if (vida == null)
        {
            vida = GetComponent<Vida_Geral>();
        }

        vida.FeedBack_Dano = Mudar_Cor;

        if (mesh == null)
            mesh = GetComponent<Renderer>();

        normalMaterial = mesh.material;

        vida.NofimDaVida = Morrer;
    }

    private void OnCollisionStay(Collision other)
    {
        //Caso encontre um collider e o nome dele seja Player executamos oque esta dentro do If
        if (other.gameObject.tag.Equals("Inimigo"))
        {
            //pedimos para executar uma funcao que simula um certo tipo de cadencia e que depois ira direcionar para outra funcao que dara o dano
            DarDano(other);            
        }

    }

    public void DarDano(Collision other)
    {
        //aprica o dano no objeto
        var inimigo = other.gameObject.GetComponent<Inimigo>();
        //Debug.Log("Essa eh a minha vida"+inimigo.vida.totalVida);
        if (inimigo != null)
        {
            
            if (posso_dar_dano)
            {
                inimigo.vida.Dano(dano);
                StartCoroutine(Resetar_Posso_Dar_Dano());
            }            
        }
    }

    public void Mudar_Cor()
    {
        barra_de_vida.Update_Barra_de_Vida(vida.totalVida / vida.vidaCheia);
        mesh.material = damageMaterial;
        Invoke(nameof(Voltar_Cor), 0.5f);
    }

    public void Voltar_Cor()
    {
        mesh.material = normalMaterial;
    }

    public IEnumerator Resetar_Posso_Dar_Dano() 
    {
        posso_dar_dano = false;
        yield return new WaitForSeconds(cadencia);
        posso_dar_dano = true;
    }

    public void Morrer()
    {
        UnitManager.instance.RemoveUnit(gameObject);
        Destroy(gameObject);
    }
}
