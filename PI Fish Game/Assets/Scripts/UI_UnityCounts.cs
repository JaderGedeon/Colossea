using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UnityCounts : MonoBehaviour
{
    private Formation formation;
    UnitManager unitManager;
    Text text;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        unitManager = UnitManager.instance;
        formation = unitManager.unitFormation;
        formation.refreshUI.AddListener(OnRefresh);
        text =  GetComponent<Text>();
        OnRefresh();
    }

    public void OnRefresh()
    {
        text.text = formation.TotalUnits+ "/"+ unitManager.unitLimitCap;
    }
}
