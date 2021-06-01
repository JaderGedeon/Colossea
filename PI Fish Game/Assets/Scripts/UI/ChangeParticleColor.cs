using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Zones
{
    InnerCircle,
    ExternalCircle,
    Crab,
    Ship,
    UFO,
    Shark,
    Corals,
    Anchor
}

public class ChangeParticleColor : MonoBehaviour
{

    public Zones selectedZone;
    public Color corzinha = new Color(0, 0, 0, 96 / 255f);

    private void Update()
    {
        ChangeColor(corzinha);
    }

    public void ChangeColor(Color color) {

        var particleSystem = gameObject.GetComponent<ParticleSystem>().main;
        particleSystem.startColor = color;
    }
}
