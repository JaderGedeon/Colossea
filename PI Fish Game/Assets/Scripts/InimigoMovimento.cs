using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoMovimento : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posicaoPlayer;
    public float velocidade_movimento;
    private Collider[] Jogadores_Encontrados;
    public GameObject Jogador_Cacado;
    public LayerMask maskJogador;
    public GameObject[] grupo;
    public float max_patrol_range = 50;
    public bool chegamos_destino = true;
    private Vector3 lugar_destino;
    public NavMeshAgent agente;
    private int i = 0;
    private Vector3 local_Na_Formaca = Vector3.zero;
    public bool lugar_definido = false;
    public float raio_De_Visao = 15f;

    public Vector3 Local_Na_Formaca { set => local_Na_Formaca = value; }

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        //Muda o lider do tropa
        if (grupo[i] == null)
        {
            i++;
        }

        if (Jogador_Cacado != null)
        {
            //Perseguir(Jogador_Cacado.transform.rotation);
            //Mover(Jogador_Cacado.transform.position);
            agente.SetDestination(Jogador_Cacado.transform.position);
        }
        else if (grupo[i] == this.gameObject)
        {
            //checamos para ver se chamos no local desejado caso não chagamos vamos devinir o local
            if (chegamos_destino)
            {
                agente.ResetPath();
                //já q definimos um local não precisamos definilo de novo
                chegamos_destino = false;
                lugar_definido = false;
                //daqui a alguns segundos ele escolheráum local para ter como destino
                Invoke(nameof(Patrol), 5f);
            }
            //caso o patrol já tenha rodado o lugar_definido será verdadeiro assim nos podemos nos direcionar para o local
            else if (lugar_definido)
            {
                agente.SetDestination(lugar_destino);
            }
            //caso o patrol já tenha rodado o lugar_definido será verdadeiro assim podemos verificar se já chamos no local desejado
            if (lugar_definido && (transform.position - lugar_destino).magnitude < 1f)
                //se chagamos no local desejado devemos dalar q ja chegamos no destino para definirmos outro local de destino
                chegamos_destino = true;
        }
        else if ( grupo[i] != null && grupo[i] != this.gameObject && (grupo[i].transform.position - transform.position).magnitude > 3f)
        {
            MoverParaAliado();
        }          
        
    }

    private void Patrol() 
    {
        //Randomozamos um local no mapa para o agente ir
        float Proximo_x = Random.Range(-max_patrol_range, max_patrol_range);
        float Proximo_z = Random.Range(-max_patrol_range, max_patrol_range);
        //colocamos as cordenadas dentro de um Vector 3 para facilitar
        Vector3 ponto_destino = new Vector3(Proximo_x + transform.position.x, transform.position.y, Proximo_z +transform.position.z);
        //Verificamos se esse ponto no mapa pode ser atingido
        if (Physics.Raycast(new Vector3(Proximo_x + transform.position.x, 5, Proximo_z + transform.position.z), Vector3.down))
        {
            //se o ponto no mapa pode ser atingido setamos ele como local de destino
            lugar_destino = ponto_destino;
            //e colocamos a varialvel lugar_definido como verdadeira
            lugar_definido = true;
        }

    }

    private void MoverParaAliado() 
    {
        Vector3 local = new Vector3(grupo[i].transform.position.x + local_Na_Formaca.x,
                                    0,
                                    grupo[i].transform.position.z + local_Na_Formaca.z);

        agente.SetDestination(local);
    } 

    private void Update()
    {
        Visao_Inimigo();
    }

    public void Perseguir(Quaternion jogador_rotacao) 
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, jogador_rotacao, 0.01f);
    }

    public void Mover(Vector3 jogador_posicao)
    {
        transform.position = Vector3.Lerp(transform.position, jogador_posicao, 0.01f);
    }

    public void Visao_Inimigo() 
    {
        int m = 1 << 10;
        Jogadores_Encontrados = Physics.OverlapSphere(transform.position, raio_De_Visao, m);
        if (Jogadores_Encontrados.Length > 0)
        {
            if (Jogador_Cacado == null)
            {
                Jogador_Cacado = Jogadores_Encontrados[0].gameObject;
            }
            foreach (Collider jogadores in Jogadores_Encontrados)
            {
                if (Jogador_Cacado == jogadores.gameObject)
                {
                }
                else
                {
                    Jogador_Cacado = Jogadores_Encontrados[0].gameObject;
                }
            }
        }
        else
        {
            Jogador_Cacado = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raio_De_Visao);
    }



}
