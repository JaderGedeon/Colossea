using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{

    public static ZoneManager instance;

    public ChangeParticleColor[] particleColors;
    private Color whiteColor = new Color(1, 1, 1, 96 / 255f);

    private void Awake()
    {
        if (instance)
            return;
        instance = this;
    }

    public void changeColor(Zones visitedZone)
    {
        foreach (var particle in particleColors)
        {
            if (particle.selectedZone == visitedZone)
                particle.corzinha = whiteColor;
        }
    }
}
