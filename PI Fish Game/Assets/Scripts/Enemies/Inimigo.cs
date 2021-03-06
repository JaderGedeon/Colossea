using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update
    public Vida_Geral vida;
    public float dano;
    GameObject jogador_cacado = null;
    public float cadencia = 1f;
    //public Color feedBack_Cor;
    public Renderer mesh;
    public bool posso_dar_dano = true;
    public SpawnPointSetup spawnPoint;
    public bool boss = false;
    public GameObject nivel_player;
    public Nivel_Piranhas piranha;

    public Barra_de_Vida barra_de_vida;

    private Material normalMaterial;
    public Material damageMaterial;

    public GameObject deathParticle;


    private void Start()
    {

        if (vida == null)
        {
            vida = GetComponent<Vida_Geral>();
        }

        vida.FeedBack_Dano = Mudar_Cor;

        if(mesh == null)
            mesh = GetComponent<Renderer>();

        normalMaterial = mesh.material;

        vida.NofimDaVida = Morrer;

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Respawn") && !boss)
        {
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            SpawnPoints_Manager.RemoverUnidades();
            Destroy(gameObject);            
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
        if(boss)
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
        var spawnPosition = gameObject.transform.position;
        SpawnPoints_Manager.RemoverUnidades();
        //GetComponent<Instanciar_Novo_Jogador>().Invocar_Jogador();
        Destroy(gameObject.GetComponent<NavMeshAgent>());
        UnitManager.instance.UnitSpawn(this.transform.position,nivel_player);

        /*switch (piranha)
        {
            case Nivel_Piranhas.Nivel_4:
                
                break;
            default:
                FindObjectOfType<SoundManagerScript>().PlaySound("Converte");
                break;
        }*/
        FindObjectOfType<SoundManagerScript>().PlaySound("ConverteOsso");
        Instantiate(deathParticle, transform.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Random.Range(0.0f, 360.0f)));
        Destroy(gameObject);
        
    }
}
