using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Object gameScene;
    public GameObject imagem;
    RawImage imageTexture;
    VideoPlayer clip;
    public Text tutorialUIText;
    [SerializeField] private GameObject video;
    public Texture[] sprites;
    public VideoClip[] videos;
    public string[] tutorialTexts;
    private int proxima_imagem = 0;

    
    private void Start()
    {
        Debug.Log("Inicializei");
        imageTexture = imagem.GetComponent<RawImage>();
        clip = video.GetComponent<VideoPlayer>();
        imageTexture.texture = sprites[proxima_imagem];
        clip.clip = videos[proxima_imagem];
    }

    public void ProximaImagem()
    {
        proxima_imagem += 1;
        if (proxima_imagem > sprites.Length - 1)
            proxima_imagem = 0;
        imageTexture.texture = sprites[proxima_imagem];
        clip.clip = videos[proxima_imagem];
        tutorialUIText.text = tutorialTexts[proxima_imagem];
        //Debug.Log(videos[proxima_imagem].name);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoBackMenu()
    {
        SceneManager.LoadScene(0);
    }
}

