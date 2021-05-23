
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSetup : MonoBehaviour
{ 
    public int dificuldade;
    private int quantidade_inimigo;
    private GameObject[] Grupo_de_Inimigos;
    public GameObject Inimigo;
    private List<Vector3> formacao_inimiga = new List<Vector3>();
    public SphereCollider collider;
    private int min, max;
    private int base_min, base_max;
    public static int unidades_spawnpont;
    private int distancia;

    // Start is called before the first frame update
    public void Setup()
    {
        dificuldade = Random.Range(1, 4);
    }

    public void Atualiza_Status(float multiplicador) 
    {
        this.min = (int)(base_min*multiplicador);
        this.max = (int)(base_max * multiplicador);
    }

    public void Iniciar(GameObject Inimigo, int min, int max, int dificuldade, int distancia)
    {
        this.min = min;
        this.max = max;
        base_min = min;
        base_max = max;
        this.Inimigo = Inimigo;
        this.dificuldade = dificuldade;
        this.distancia = distancia;
        formacao();
        InvokeRepeating(nameof(SpanwPoint), Random.Range(3, 15), Random.Range(5, 8));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zonas")
        {
            //Parar_Invoke();    
        }
    }

    public void Parar_Invoke() 
    {
        CancelInvoke();
        InvokeRepeating(nameof(SpanwPoint), Random.Range(3, 10), Random.Range(2, 5));
    }

    public void SpanwPoint()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 8) && unidades_spawnpont <= 99)
        {
            int quantos_inimigos = Random.Range(min, max);

            Grupo_de_Inimigos = new GameObject[quantos_inimigos];

            for (int i = 0; i < quantos_inimigos; i++)
            {
                Grupo_de_Inimigos[i] = Instantiate(Inimigo, transform.position+formacao_inimiga[i],Quaternion.identity);
                var inimigo_movimento = Grupo_de_Inimigos[i].GetComponent<InimigoMovimento>();
                inimigo_movimento.grupo = Grupo_de_Inimigos;
                inimigo_movimento.Local_Na_Formaca = formacao_inimiga[i];
                unidades_spawnpont++;
            }

            SpawnPoints_Manager.Armazem_de_Grupos.Add(Grupo_de_Inimigos);
        }
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
