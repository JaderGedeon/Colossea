using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints_Manager : MonoBehaviour
{
    public List<SpawnPointSetup> spawnPointSetups;
    private GameObject[] Grupo_de_Inimigos;
    static public List<GameObject[]> Armazem_de_Grupos = new List<GameObject[]>();
    public GameObject Inimigo;
    private List<Vector3> formacao_inimiga = new List<Vector3>();
    public UnitManager unitManager;

    void Start()
    {
        foreach (SpawnPointSetup spawn_points in spawnPointSetups)
        {
            spawn_points.Setup();

            switch (spawn_points.dificuldade)
            {
                case 1:
                    Debug.Log("SpawPoint_Facil");
                    spawn_points.Iniciar(Inimigo,4,4);
                    break;
                case 2:
                    Debug.Log("SpawPoint_Medio");
                    spawn_points.Iniciar(Inimigo,6,6);
                    break;
                case 3:
                    Debug.Log("SpawPoint_Dificil");
                    spawn_points.Iniciar(Inimigo,10,10);
                    break;
                default:
                    break;
            }            
        }
        StartCoroutine(Atualiza_Dificudade());
    }

    public IEnumerator Atualiza_Dificudade()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            foreach (SpawnPointSetup spawnPoint in spawnPointSetups)
            {
                var multiplicador_unidades = Mathf.Floor(unitManager.unitFormation.TotalUnits % 25);

                spawnPoint.Atualiza_Status(1 + multiplicador_unidades * 0.25f);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zonas")
        {
            Debug.Log("Estou Colidindo com as Zonas");
        }
    }

    

}
