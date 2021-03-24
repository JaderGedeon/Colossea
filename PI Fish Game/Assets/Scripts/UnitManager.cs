using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    public GameObject unitToSpawn; // Prefab of unit
    public Transform unitsContainer; // Father in hierarchy of units
    public Formation unitFormation; // Class Formation

    public int unitLimitCap; // Limit of units to spawn
    public float distanceBetweenUnits; // Distance between units

    // Moviment Variables

    private List<PlayerMoviment> unitMovimentList = new List<PlayerMoviment>(); // List of PlayerMoviment class in each unit

    private Camera cam; // Main Camera
    private RaycastHit hit; // Raycast
    private Ray ray; // Ray

    //

    private void Start()
    {
        unitFormation = new Formation(unitCap: unitLimitCap, distance: distanceBetweenUnits);
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UnitSpawn();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < 100; i++)
            {
                UnitSpawn();
            }
        }

        if (UnitsNeedToMove())
            MoveUnits();
    }

    public bool UnitsNeedToMove() {

        ray = cam.ScreenPointToRay(Input.mousePosition);

        return Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground"));
    }

    public void MoveUnits() {

        Vector3 posHit = new Vector3(hit.point.x - unitFormation.centerPoint.GetXPosition,
                                    0,
                                    hit.point.z - unitFormation.centerPoint.GetYPosition);

        for (int i = 0, end = unitMovimentList.Count; i < end; i++)
        {
            unitMovimentList[i].Move(posHit);
        }
 
    }

    public void UnitSpawn() {

        if (unitLimitCap > unitFormation.GetTotalUnits)
        {
            unitFormation.AddUnit();

            Vector3 vectorPosition = new Vector3(
                        unitFormation.GetLastUnitCoordinate().GetXPosition,
                        transform.position.y,
                        unitFormation.GetLastUnitCoordinate().GetYPosition);

            GameObject newUnit = Instantiate(unitToSpawn, vectorPosition, Quaternion.identity, unitsContainer);

            PlayerMoviment newUnitMoviment = newUnit.GetComponent<PlayerMoviment>();

            newUnitMoviment.positionInFormation = vectorPosition;

            newUnit.gameObject.transform.position = new Vector3(hit.point.x  + vectorPosition.x - unitFormation.centerPoint.GetXPosition,
                                                                vectorPosition.y,
                                                                hit.point.z + vectorPosition.z - unitFormation.centerPoint.GetYPosition);

            newUnitMoviment.Start();

            unitMovimentList.Add(newUnitMoviment);
        }
        else {
            Debug.Log("Número máximo de unidades alcançadas");
        }
    }
}
