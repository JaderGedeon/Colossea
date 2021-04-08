using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMovimento : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posicaoPlayer;
    public float velocidade_movimento;
    private Collider[] Jogadores_Encontrados;
    public GameObject Jogador_Cacado;
    public LayerMask maskJogador;


    private void FixedUpdate()
    {
        if (Jogador_Cacado!= null)
        {
            Perseguir(Jogador_Cacado.transform.rotation);
            Mover(Jogador_Cacado.transform.position);
        }

    }

    private void Update()
    {
        Visao_Inimigo();
    }

    public void Perseguir(Quaternion jogador_rotacao) 
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, jogador_rotacao, 0.01f);
    }

    public void Mover(Vector3 jogador_posicao)
    {
        transform.position = Vector3.Lerp(transform.position, jogador_posicao, 0.01f);
    }

    public void Visao_Inimigo() 
    {
        int m = 1 << 10;
        Jogadores_Encontrados = Physics.OverlapSphere(transform.position, 15f, m);
        if (Jogadores_Encontrados.Length > 0)
        {
            if (Jogador_Cacado == null)
            {
                Jogador_Cacado = Jogadores_Encontrados[0].gameObject;
            }
            foreach (Collider jogadores in Jogadores_Encontrados)
            {
                if (Jogador_Cacado == jogadores.gameObject)
                {
                }
                else
                {
                    Jogador_Cacado = Jogadores_Encontrados[0].gameObject;
                }
            }
        }
        else
        {
            Jogador_Cacado = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }



}
