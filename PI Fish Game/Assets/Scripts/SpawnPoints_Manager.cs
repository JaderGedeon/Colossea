using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints_Manager : MonoBehaviour
{
    public List<SpawnPointSetup> spawnPointSetups;
    private GameObject[] Grupo_de_Inimigos;
    static public List<GameObject[]> Armazem_de_Grupos = new List<GameObject[]>();
    public GameObject[] Inimigo;
    private List<Vector3> formacao_inimiga = new List<Vector3>();
    public UnitManager unitManager;

    void Start()
    {
        int i = 3;
        foreach (SpawnPointSetup spawn_points in spawnPointSetups)
        {
            spawn_points.Setup();

            if (i > 0)
            {
                spawn_points.dificuldade = 1;
            }

            switch (spawn_points.dificuldade)
            {
                case 1:
                    Debug.Log("SpawPoint_Facil");
                    spawn_points.Iniciar(Inimigo[0], 2, 5, 1, 7);
                    break;
                case 2:
                    Debug.Log("SpawPoint_Medio");
                    switch (Random.Range(0,1))
                    {
                        case 0:
                            spawn_points.Iniciar(Inimigo[0], 2, 4, 2, 9);
                            break;

                        case 1:
                            spawn_points.Iniciar(Inimigo[1], 2, 4, 2, 9);
                            break;
                    }
                    break;
                case 3:
                    Debug.Log("SpawPoint_Dificil");
                    spawn_points.Iniciar(Inimigo[1], 3, 5, 3, 9);
                    break;
                default:
                    break;
            }
            i--;
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
            //Debug.Log("Estou Colidindo com as Zonas");
        }
    }

    

}
