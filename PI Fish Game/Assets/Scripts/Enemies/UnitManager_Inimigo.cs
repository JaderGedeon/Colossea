using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager_Inimigo : MonoBehaviour
{

    public Transform[] SpawnPoints;
    private GameObject[] Grupo_de_Inimigos;
    private List<GameObject[]> Armazem_de_Grupos;
    public GameObject Inimigo;
    private List<Vector3> formacao_inimiga = new List<Vector3>();
    public List<SpawnPoints_Manager> spawnpoints_managers;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(Instanciar_Lista_de_Inimigos), 1f, 20f);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Armazem_de_Grupos != null)
        {
            foreach (GameObject[] Grupos_de_Inimigos in Armazem_de_Grupos)
            {
                if (Grupo_de_Inimigos == null)
                {
                    Armazem_de_Grupos.Remove(Grupos_de_Inimigos);
                }
            }            
        }
    }


    public void Instanciar_Lista_de_Inimigos() 
    {
        int quantos_inimigos = Random.Range(1, 4);

        int spawnPoint = Random.Range(0, SpawnPoints.Length-1);

        Grupo_de_Inimigos = new GameObject[quantos_inimigos];

        for (int i = 0; i < quantos_inimigos; i++)
        {
            Grupo_de_Inimigos[i] = Instantiate(Inimigo, SpawnPoints[spawnPoint]);
            var inimigo_movimento = Grupo_de_Inimigos[i].GetComponent<InimigoMovimento>();
            inimigo_movimento.grupo = Grupo_de_Inimigos;
            inimigo_movimento.Local_Na_Formaca = formacao_inimiga[i];
        }
        if (Armazem_de_Grupos!=null)
        {
            Armazem_de_Grupos.Add(Grupo_de_Inimigos);
        }
    }*/
}
