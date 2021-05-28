using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dificudade
{
    Facil,
    Medio,
    Dificil
}
public class SpawnPoints_Manager : MonoBehaviour
{
    public List<SpawnPointSetup> spawnPointSetups;
    private GameObject[] Grupo_de_Inimigos;
    static public List<GameObject[]> Armazem_de_Grupos = new List<GameObject[]>();
    public GameObject[] Inimigo;
    private List<Vector3> formacao_inimiga = new List<Vector3>();
    public UnitManager unitManager;
    public static SpawnPoints_Manager instance;
    public int unidades_spawnpoint;
    public int capMax = 25;


    public static void AdcionarUnidades() { instance.unidades_spawnpoint++; }
    public static void RemoverUnidades() { instance.unidades_spawnpoint--; }
    public static int TotalUnidades() { return instance.unidades_spawnpoint; }
    public static int Cap() { return instance.capMax; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this) 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        int i = 3;
        foreach (SpawnPointSetup spawn_points in spawnPointSetups)
        {
            spawn_points.Setup();

            if (i > 0)
            {
                spawn_points.dificudade = Dificudade.Facil;
            }

            switch (spawn_points.dificudade)
            {
                case Dificudade.Facil:
                    Debug.Log("SpawPoint_Facil");
                    spawn_points.Iniciar(Inimigo[0], 2, 5, Dificudade.Facil, 7);
                    break;
                case Dificudade.Medio:
                    Debug.Log("SpawPoint_Medio");
                    switch (Random.Range(0,1))
                    {
                        case 0:
                            spawn_points.Iniciar(Inimigo[0], 2, 4, Dificudade.Medio, 9);
                            break;

                        case 1:
                            spawn_points.Iniciar(Inimigo[1], 2, 4, Dificudade.Medio, 9);
                            break;
                    }
                    break;
                case Dificudade.Dificil:
                    Debug.Log("SpawPoint_Dificil");
                    spawn_points.Iniciar(Inimigo[1], 3, 5, Dificudade.Dificil, 9);
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
