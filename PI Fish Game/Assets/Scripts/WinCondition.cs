using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    public Vida_Geral vida;

    private void Update()
    {
        if (vida.totalVida < 5) {
            SceneManager.LoadScene(3);
            return;
        }
    }
}
