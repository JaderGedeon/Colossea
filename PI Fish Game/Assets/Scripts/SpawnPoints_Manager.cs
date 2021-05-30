using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dificudade
{
    Facil,
    Medio,
    Dificil
}
public enum Nivel_Piranhas
{
    Nivel_1,
    Nivel_2,
    Nivel_3,
    Nivel_4
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
    public Spawn_Points[] Spawn_Points_Array;

    public static void AdcionarUnidades() { instance.unidades_spawnpoint++; }
    public static void RemoverUnidades() { instance.unidades_spawnpoint--; }
    public static int TotalUnidades() { return instance.unidades_spawnpoint; }
    public static int Cap() { return instance.capMax; }
    public static void SetarCap(int capMax) { instance.capMax = capMax; }

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
                spawn_points.Iniciar(Spawn_Points_Array[0]);
            }
            spawn_points.Iniciar(Spawn_Points_Array[Random.Range(0, 2)]);
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
