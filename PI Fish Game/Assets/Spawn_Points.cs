using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Spanw_Points",menuName = "Spanw_Points")]
public class Spawn_Points : ScriptableObject
{
    public Dificudade dificudade;
    public List<GameObject> inimigos;
    //public List<GameObject> inimigos_disponivei;
    public int numero_max, numero_min;
    public int intervalo_max, intervalo_min;

    //Na zona normal um spawn point de nivel facil ira spawnar um tipo de peixe Lv 1
    //Na zona normal um spawn point de nivel medio ira spawnar dois tipos de peixes Lv 1 e Lv 2
    //Na zona normal um spawn point de nivel dificil ira spawnar um tipo de peixe Lv 2

    public List<GameObject> Voltando_Area_Normal(List<GameObject> inimigos_disponiveis) 
    {
        inimigos_disponiveis.Clear();
        switch (dificudade)
        {
            case Dificudade.Facil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_1]);
                return inimigos_disponiveis;
            case Dificudade.Medio:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_1]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            case Dificudade.Dificil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            default:
                return inimigos_disponiveis;
        }
    }

    public List<GameObject> Detecta_Area(string area,List<GameObject> inimigos_disponiveis) 
    {
        inimigos_disponiveis.Clear();
        switch (int.Parse(area))
        {
            case 1:
                return Atualizar_Status_Zona_1(inimigos_disponiveis);
            case 2:
                return Atualizar_Status_Zona_2(inimigos_disponiveis);
            case 3:
                return Atualizar_Status_Zona_3(inimigos_disponiveis);
            case 4:
                return Atualizar_Status_Zona_4(inimigos_disponiveis);
            case 5:
                return Atualizar_Status_Zona_5(inimigos_disponiveis);
            default:
                return inimigos_disponiveis;
        }
    }

    //Na zona_1 um spawn point de nivel facil ira spawnar dois tipos de peixes Lv 1 e Lv 2
    //Na zona_1 um spawn point de nivel medio ira spawnar um tipo de peixes Lv 2
    //Na zona_1 um spawn point de nivel dificil ira spawnar dois tipos de peixes Lv 2 e Lv 3

    public List<GameObject> Atualizar_Status_Zona_1(List<GameObject> inimigos_disponiveis) {
        switch (this.dificudade)
        {
            case Dificudade.Facil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_1]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            case Dificudade.Medio:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            case Dificudade.Dificil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            default:
                return inimigos_disponiveis;
        }
    }

    //Na zona_2 um spawn point de nivel facil ira spawnar um tipo de peixes Lv 2
    //Na zona_2 um spawn point de nivel medio ira spawnar um tipo de peixes Lv 2
    //Na zona_2 um spawn point de nivel dificil ira spawnar um tipo de peixes Lv 3
    public List<GameObject> Atualizar_Status_Zona_2(List<GameObject> inimigos_disponiveis) {

        switch (this.dificudade)
        {
            case Dificudade.Facil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            case Dificudade.Medio:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            case Dificudade.Dificil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            default:
                return inimigos_disponiveis;
        }
    }

    //Na zona_3 um spawn point de nivel facil ira spawnar um tipo de peixes Lv 2
    //Na zona_3 um spawn point de nivel medio ira spawnar dois tipos de peixes Lv 2 e Lv 3
    //Na zona_3 um spawn point de nivel dificil ira spawnar um tipo de peixes Lv 3
    public List<GameObject> Atualizar_Status_Zona_3(List<GameObject> inimigos_disponiveis) {
        switch (this.dificudade)
        {
            case Dificudade.Facil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                return inimigos_disponiveis;
            case Dificudade.Medio:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            case Dificudade.Dificil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            default:
                return inimigos_disponiveis;
        }
    }

    //Na zona_4 um spawn point de nivel facil ira spawnar dois tipos de peixes Lv 2 e Lv 3
    //Na zona_4 um spawn point de nivel medio ira spawnar dois tipos de peixes Lv 2 e Lv 3
    //Na zona_4 um spawn point de nivel dificil ira spawnar dois tipos de peixes Lv 3 e Lv 4
    public List<GameObject> Atualizar_Status_Zona_4(List<GameObject> inimigos_disponiveis) {
        switch (this.dificudade)
        {
            case Dificudade.Facil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            case Dificudade.Medio:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            case Dificudade.Dificil:
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_4]);
                return inimigos_disponiveis;
            default:
                return inimigos_disponiveis;
        }
    }

    //Na zona_5 um spawn point de nivel facil ira spawnar dois tipos de peixes Lv 2 e Lv 3
    //Na zona_5 um spawn point de nivel medio ira spawnar um tipo de peixes Lv 3
    //Na zona_5 um spawn point de nivel dificil ira spawnar um tipo de peixes Lv 4
    public List<GameObject> Atualizar_Status_Zona_5(List<GameObject> inimigos_disponiveis) {
        Debug.Log(dificudade);
        switch (dificudade)
        {
            case Dificudade.Facil:
                Debug.Log("Piranhas Multiplas");
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_2]);
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            case Dificudade.Medio:
                Debug.Log("Piranha Demonio");
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_3]);
                return inimigos_disponiveis;
            case Dificudade.Dificil:
                Debug.Log("Piranha Osso");
                inimigos_disponiveis.Add(inimigos[(int)Nivel_Piranhas.Nivel_4]);
                return inimigos_disponiveis;
            default:
                Debug.Log("Caiu no default");
                return inimigos_disponiveis;
        }
    }
}
