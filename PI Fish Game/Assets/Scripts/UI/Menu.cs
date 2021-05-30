using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Object gameScene;
    public GameObject[] escitas;
    public GameObject imagem;
    public Texture[] sprites;
    public GameObject botao_proximo;
    public GameObject voltar;
    public GameObject tutorial;
    private int proxima_imagem = 0;
    public static bool tutorial_visto = false;

    public void PlayGame()
    {
        if (!tutorial_visto)
        {
            tutorial_visto = true;
            SceneManager.LoadScene("Tutorial");            
        }
        else
            SceneManager.LoadScene(1);
        
    }

    public void GoToInitialMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        foreach (GameObject escrito in escitas)
        {
            escrito.SetActive(false);
        }
        imagem.SetActive(true);
        imagem.GetComponent<RawImage>().texture = sprites[proxima_imagem];
        botao_proximo.SetActive(true);
        voltar.SetActive(true);
        tutorial.SetActive(false);
    }

    public void ProximaImagem()
    {
        proxima_imagem += 1;
        if (proxima_imagem>sprites.Length-1)
        {
            proxima_imagem = 0;
        }        
        imagem.GetComponent<RawImage>().texture = sprites[proxima_imagem];
    }
    public void Voltar()
    {
        foreach (GameObject escrito in escitas)
        {
            escrito.SetActive(true);
        }
        imagem.SetActive(false);
        botao_proximo.SetActive(false);
        voltar.SetActive(false);
        tutorial.SetActive(true);
    }
}
