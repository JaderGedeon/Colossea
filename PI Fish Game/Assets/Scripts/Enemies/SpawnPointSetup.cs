
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSetup : MonoBehaviour
{
    public Spawn_Points spawn_points;
    //public int dificuldade;
    //private int quantidade_inimigo;
    private GameObject[] Grupo_de_Inimigos;
    private List<GameObject> inimigos_disponiveis = new List<GameObject>();
    //public GameObject Inimigo;
    private List<Vector3> formacao_inimiga = new List<Vector3>();
    //public SphereCollider collider;
    private int min, max;
    private int base_min, base_max;
    private int distancia = 10;
    //public int valor_debug;

    public Dificudade dificudade;

    // Start is called before the first frame update
    public void Setup()
    {
        dificudade = (Dificudade)Random.Range(0, System.Enum.GetNames(typeof(Dificudade)).Length);
    }

    public void Atualiza_Status(float multiplicador)
    {
        this.min = (int)(spawn_points.numero_min * multiplicador);
        this.max = (int)(spawn_points.numero_max * multiplicador);
    }

    public void Iniciar(Spawn_Points spawn_)
    {
        this.spawn_points = spawn_;
        this.min = spawn_.numero_min;
        this.max = spawn_.numero_max;
        inimigos_disponiveis = spawn_.Voltando_Area_Normal(inimigos_disponiveis);
        formacao();
        InvokeRepeating(nameof(SpanwPoint), 1, Random.Range(5, 8));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zonas")
        {
            CancelInvoke();
            Debug.Log("Nivel desse Spawn"+spawn_points.dificudade);
            inimigos_disponiveis = spawn_points.Detecta_Area(other.name,inimigos_disponiveis);
            InvokeRepeating(nameof(SpanwPoint), 1, Random.Range(5, 8));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zonas")
        {
            //Debug.Log("SpawnPoint_Resetado");
            CancelInvoke();
            inimigos_disponiveis = spawn_points.Voltando_Area_Normal(inimigos_disponiveis);
            InvokeRepeating(nameof(SpanwPoint), 1, Random.Range(5, 8));
        }
    }

    public void SpanwPoint()
    {
        RaycastHit hit;
        int layerMask_objeto = 1 << 12;
        int layerMask_inimigo = 1 << 1;
        int quantos_inimigos = Random.Range(min, max);

        Grupo_de_Inimigos = new GameObject[quantos_inimigos];


        for (int i = 0; i < quantos_inimigos; i++)
        {
            Vector3 vector = transform.position + formacao_inimiga[i];
            vector.y = 50;
            if (!Physics.Raycast(vector, Vector3.down, out hit, Mathf.Infinity, layerMask_objeto, QueryTriggerInteraction.Collide) && SpawnPoints_Manager.TotalUnidades() <= SpawnPoints_Manager.Cap() && !Physics.Raycast(vector, Vector3.down, out hit, Mathf.Infinity, layerMask_inimigo))
            {
                //Debug.Log(SpawnPoints_Manager.TotalUnidades());
                var randomizado = Random.Range(0, inimigos_disponiveis.Count);
                var randomizou = randomizado;
                Grupo_de_Inimigos[i] = Instantiate(inimigos_disponiveis[randomizou], transform.position + formacao_inimiga[i], Quaternion.identity);
                Grupo_de_Inimigos[i].GetComponent<Inimigo>().deathParticle = SpawnPoints_Manager.instance.Particulas[randomizou];
                Grupo_de_Inimigos[i].GetComponent<Inimigo>().piranha = (Nivel_Piranhas)randomizou;
                var inimigo_movimento = Grupo_de_Inimigos[i].GetComponent<InimigoMovimento>();
                inimigo_movimento.grupo = Grupo_de_Inimigos;
                inimigo_movimento.Local_Na_Formaca = formacao_inimiga[i];
                SpawnPoints_Manager.AdcionarUnidades();
            }
            else
                break;

        }

        SpawnPoints_Manager.Armazem_de_Grupos.Add(Grupo_de_Inimigos);

    }

    public void formacao()
    {
        for (int i = 0; i < 100; i++)
        {
            formacao_inimiga.Add(new Vector3(0, 0, 0));
            formacao_inimiga.Add(new Vector3(distancia, 0, distancia));
            formacao_inimiga.Add(new Vector3(distancia, 0, 0));
            formacao_inimiga.Add(new Vector3(0, 0, distancia));
            distancia += distancia;
        }
    }
}
