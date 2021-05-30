using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Object gameScene;
    public GameObject imagem;
    public Texture[] sprites;
    private int proxima_imagem = 0;

    
    private void Start()
    {
        Debug.Log("Inicializei");
        imagem.GetComponent<RawImage>().texture = sprites[proxima_imagem];
    }

    public void ProximaImagem()
    {
        proxima_imagem += 1;
        if (proxima_imagem > sprites.Length - 1)
        {
            proxima_imagem = 0;
        }
        imagem.GetComponent<RawImage>().texture = sprites[proxima_imagem];
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}

