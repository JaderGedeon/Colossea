using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    public Unit[] units;
    public Transform unitsContainer;
    public Formation unitFormation;

    public int unitLimitCap;
    public float distanceBetweenUnits;


    // Moviment

    public Camera cam = Camera.main;
    public RaycastHit hit;
    public Ray ray;

    public List<PlayerMoviment> movimentList;

    // =======

    private void Start()
    {
        unitFormation = new Formation(unitCap: unitLimitCap, distance: distanceBetweenUnits);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UnitSpawn();
        }

        if (UnitsNeedToMove()) { 
            


        }
    }

    public bool UnitsNeedToMove() {

        ray = cam.ScreenPointToRay(Input.mousePosition);

        return (Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground")));
    }

    public void moveUnits() {


    
    }


    public void UnitSpawn() {

        if (unitLimitCap > unitFormation.GetTotalUnits)
        {

            Vector3 vectorPosition = new Vector3(
                        unitFormation.GetLastUnitCoordinate().GetXPosition, gameObject.transform.position.y,
                        unitFormation.GetLastUnitCoordinate().GetYPosition);

            Unit newUnit = Instantiate(units[0], vectorPosition, Quaternion.identity, unitsContainer);
            newUnit.GetComponent<PlayerMoviment>().positionInFormation = vectorPosition;

            movimentList.Add(newUnit.GetComponent<PlayerMoviment>());

            unitFormation.AddUnit();

        }
        else {
            Debug.Log("Número máximo de unidades alcançadas");
        }
    }
}
