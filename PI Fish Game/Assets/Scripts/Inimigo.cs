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
    public Color feedBack_Cor;
    public Renderer mesh;
    public bool posso_dar_dano = true;
    public SpawnPointSetup spawnPoint;
    public bool boss = false;


    private void Start()
    {

        if (vida == null)
        {
            vida = GetComponent<Vida_Geral>();
        }

        vida.FeedBack_Dano = Mudar_Cor;

        if(mesh == null)
            mesh = GetComponent<Renderer>();

        feedBack_Cor = mesh.material.GetColor("_Color");

        vida.NofimDaVida = Morrer;

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Respawn") && !boss)
        {
            Destroy(gameObject);
            SpawnPointSetup.unidades_spawnpont--;
        }
    }

    private void OnCollisionStay(Collision other)
    {

        //Caso encontre um collider e o nome dele seja Player executamos oque esta dentro do If
        if (other.gameObject.tag.Equals("Unit") && posso_dar_dano)
        {

            if (jogador_cacado == null || jogador_cacado == other.gameObject)
            {
                jogador_cacado = other.gameObject;
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
            if (posso_dar_dano)
            {
                player.vida.Dano(dano);
                StartCoroutine(Resetar_Posso_Dar_Dano());
            }
            if (player.vida.totalVida-player.dano <= 0 || player == null)
            {
                jogador_cacado = null;
            }
        }

    }

    public void Mudar_Cor() 
    {
        mesh.material.color = new Color(50, feedBack_Cor.g, feedBack_Cor.b);
        Invoke(nameof(Voltar_Cor), 0.5f);
    }

    public void Voltar_Cor() 
    {
        mesh.material.color = new Color(feedBack_Cor.r, feedBack_Cor.g, feedBack_Cor.b);
    }

    public IEnumerator Resetar_Posso_Dar_Dano()
    {
        posso_dar_dano = false;
        yield return new WaitForSeconds(cadencia);
        posso_dar_dano = true;
    }

    public void Morrer()
    {
        FindObjectOfType<UnitManager>().UnitSpawn();
        SpawnPointSetup.unidades_spawnpont--;
        //GetComponent<Instanciar_Novo_Jogador>().Invocar_Jogador();
        Destroy(gameObject);
    }
}
