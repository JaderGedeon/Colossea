using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << 12;
        if (!Physics.Raycast(this.transform.position, Vector3.down, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide))
        {
            //Debug.Log("Posso Spanar aqui");
        }
        else
        {
           //Debug.Log("Não Posso Spanar aqui");
        }
    }
}
