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

        if (Input.GetKeyDown(KeyCode.B))
        {
            unitFormation.PrintSaPoha();
        }
    }


    public void UnitSpawn() {

        if (unitLimitCap > unitFormation.GetTotalUnits)
        {

            Vector3 vectorPosition = new Vector3(
                        unitFormation.GetLastUnitCoordinate().GetXPosition, gameObject.transform.position.y,
                        unitFormation.GetLastUnitCoordinate().GetYPosition);

            Unit newUnit = Instantiate(units[0], vectorPosition, Quaternion.identity, unitsContainer);
            newUnit.GetComponent<PlayerMoviment>().positionInFormation = vectorPosition;

            unitFormation.AddUnit();

        }
        else {
            Debug.Log("Número máximo de unidades alcançadas");
        }
    }
}
