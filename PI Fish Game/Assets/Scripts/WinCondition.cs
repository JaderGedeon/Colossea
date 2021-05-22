using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    void OnDestroy()
    {
        SceneManager.LoadScene(3);
        return;
    }
}
