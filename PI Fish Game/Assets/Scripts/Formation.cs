using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{

    private int unitCap;
    private int totalUnits = 0;
    private int numDiag;
    private float distance;
    private List<CoordinatePoint> coordinatesList = new List<CoordinatePoint>();
    public CoordinatePoint centerPoint = new CoordinatePoint(0, 0);
    private int[] numInSideOfSquare = { 1, 1 };

    public int GetTotalUnits { get => totalUnits; }

    public Formation(int unitCap, float distance)
    {
        coordinatesList.Add(new CoordinatePoint(0, 0));
        numDiag = 1;

        this.unitCap = unitCap;
        this.distance = distance;

    }

    public CoordinatePoint GetLastUnitCoordinate()
    {

        return coordinatesList[coordinatesList.Count - 1];

    }

    public void AddUnit()
    {

        if (totalUnits < unitCap)
        {
            if (totalUnits == 0) {
                totalUnits++;
                return;
            }

            // Adiciona unidade na diagonal
            if (totalUnits == Mathf.Pow(numDiag, 2))
            {
                numDiag++;

                coordinatesList.Add(new CoordinatePoint((centerPoint.GetXPosition * 2) + distance,
                    (centerPoint.GetYPosition * 2) + distance));

                centerPoint.SetXPosition = (numDiag - 1) * distance / 2;
                centerPoint.SetYPosition = (numDiag - 1) * distance / 2;

                numInSideOfSquare[0] = 1;
                numInSideOfSquare[1] = 1;
            }
            else
            {
                if ((totalUnits + 1) % 2 == 0)
                {
                    // Adiciona unidade para cima
                    coordinatesList.Add(new CoordinatePoint(((centerPoint.GetXPosition * 2)) - distance * numInSideOfSquare[0],
                        (centerPoint.GetYPosition * 2)));

                    numInSideOfSquare[0] += 1;

                }
                else
                {
                    // Adiciona unidade para esquerda
                    coordinatesList.Add(new CoordinatePoint((centerPoint.GetXPosition * 2),
                        ((centerPoint.GetYPosition * 2)) - distance * numInSideOfSquare[1]));

                    numInSideOfSquare[1] += 1;
                }
            }
            totalUnits++;
        }
        else
        {
            Debug.Log("Número máximo de unidades alcançadas");
        }
    }
}

public class CoordinatePoint
{

    private float xPosition, yPosition;

    public CoordinatePoint(float xPosition, float yPosition)
    {

        this.xPosition = xPosition;
        this.yPosition = yPosition;

    }

    public float GetXPosition { get => xPosition; }
    public float GetYPosition { get => yPosition; }

    public float SetXPosition { set => xPosition = value; }
    public float SetYPosition { set => yPosition = value; }
}



