using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{

    private int totalUnits = 0;
    private float distanceBetweenUnits;
    private List<CoordinatePoint> coordinatesList = new List<CoordinatePoint>();
    private float[] centerPoint = new float[] { 0, 0 };

    private int numDiag;
    private int[] numInSideOfSquare = { 1, 1 };

    public Formation(float distance)
    {
        coordinatesList.Add(new CoordinatePoint(0, 0));
        numDiag = 1;

        distanceBetweenUnits = distance;
    }

    public void AddUnit()
    {
        if (totalUnits == 0)
        {
            totalUnits++;
            return;
        }

        // Adiciona unidade na diagonal
        if (totalUnits == Mathf.Pow(numDiag, 2))
        {
            numDiag++;

            coordinatesList.Add(new CoordinatePoint(centerPoint[0] * 2 + distanceBetweenUnits,
                                                    centerPoint[1] * 2 + distanceBetweenUnits));

            centerPoint = new float[] { (numDiag - 1) * distanceBetweenUnits / 2,
                                        (numDiag - 1) * distanceBetweenUnits / 2 };

            numInSideOfSquare = new int[] { 1, 1 };

        }
        else
        {
            if ((totalUnits + 1) % 2 == 0)
            {
                // Adiciona unidade para cima
                coordinatesList.Add(new CoordinatePoint(centerPoint[0] * 2 - distanceBetweenUnits * numInSideOfSquare[0],
                                                        centerPoint[1] * 2));

                numInSideOfSquare[0] += 1;

            }
            else
            {
                // Adiciona unidade para esquerda
                coordinatesList.Add(new CoordinatePoint(centerPoint[0] * 2,
                                                        centerPoint[1] * 2 - distanceBetweenUnits * numInSideOfSquare[1]));

                numInSideOfSquare[1] += 1;
            }
        }
        totalUnits++;
    }
    public int GetTotalUnits => totalUnits;
    public float[] CenterPoint => centerPoint;
    public CoordinatePoint GetLastUnitCoordinate => coordinatesList[coordinatesList.Count - 1];
}

public class CoordinatePoint
{
    private float xPosition, zPosition;

    public CoordinatePoint(float xPosition, float zPosition)
    {
        this.xPosition = xPosition;
        this.zPosition = zPosition;
    }
    public float[] GetXandZPosition => new float[] { xPosition, zPosition };
}



