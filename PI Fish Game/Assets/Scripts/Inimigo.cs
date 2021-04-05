using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public Vida_Geral vida;
    public float dano;
    GameObject jogador_cacado = null;
    public float cadencia = 1f;
    private Color feedBack_Cor;
    Renderer mesh;
    public bool posso_dar_dano = true;

    private void Start()
    {

        if (vida == null)
        {
            vida = GetComponent<Vida_Geral>();
        }

        vida.FeedBack_Dano = Mudar_Cor;

        mesh = GetComponent<Renderer>();

        feedBack_Cor = mesh.material.GetColor("_Color");

        vida.NofimDaVida = Morrer;

    }

    private void OnCollisionEnter(Collision other)
    {

        //Caso encontre um collider e o nome dele seja Player executamos oque esta dentro do If
        if (other.gameObject.tag.Equals("Unit") && other.gameObject.GetComponent<Player>().posso_dar_dano)
        {

            StartCoroutine(other.gameObject.GetComponent<Player>().Resetar_Posso_Dar_Dano());

            if (jogador_cacado == null || jogador_cacado == other.gameObject)
            {
                jogador_cacado = other.gameObject;
                //pedimos para executar uma funcao que simula um certo tipo de cadencia e que depois ira direcionar para outra funcao que dara o dano
                DarDano(other);
            }            
        }        
    }


    public void DarDano(Collision other)
    {
        //aprica o dano no objeto
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            vida.Dano(player.dano);
            if (player.vida.totalVida-player.dano <= 0 || player == null)
            {
                jogador_cacado = null;
            }
        }

    }

    public void Mudar_Cor() 
    {
        mesh.material.color = new Color(50, feedBack_Cor.g, feedBack_Cor.b);
        Invoke(nameof(Voltar_Cor), 1);
    }

    public void Voltar_Cor() 
    {
        mesh.material.color = new Color(feedBack_Cor.r, feedBack_Cor.g, feedBack_Cor.b);
    }

    public IEnumerator Resetar_Posso_Dar_Dano()
    {
        posso_dar_dano = false;
        yield return cadencia;
        posso_dar_dano = true;
    }

    public void Morrer()
    {
        //GetComponent<Instanciar_Novo_Jogador>().Invocar_Jogador();
        Destroy(gameObject);
    }
}
