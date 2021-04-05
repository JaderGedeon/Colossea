using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;

    private void Awake()
    {
        if (Instance ==  null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public UnityEvent JogoProntoEvent = new UnityEvent();

    bool _JogoPronto;

    public bool JogoEstaPronto
    {
        get { return _JogoPronto; }
    }

    void Start()
    {
        _JogoPronto = true;
        JogoProntoEvent.Invoke();
    }

    public static void AddJogoProntoListener(UnityAction _listener) 
    {
        Instance.JogoProntoEvent.AddListener(_listener);
    }

}
