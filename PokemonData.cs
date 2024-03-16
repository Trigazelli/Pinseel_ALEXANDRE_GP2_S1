using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{

    public string name = "Volcarona";
    public int BaseLife = 200;
    private int CurrentLife;
    public int Atk = 135;
    public int Def = 105;
    private int StatPoints;
    public float Weight = 46.0f;
    public enum Types
    {
        Fire,
        Grass,
        Water,
        Ground,
        Rock,
        Normal,
        Fighting,
        Shadow,
        Dark,
        Electrik,
        Psychic,
        Bug,
        Fairy,
        Steel,
        Poison,
        Flying,
        Dragon,
        Ice
    };

    public Types[] types = { Types.Bug, Types.Fire };
    public Types[] Weaknesses = { Types.Rock, Types.Water, Types.Flying};
    public Types[] Resistances = { Types.Grass, Types.Fairy, Types.Bug, Types.Fighting, Types.Ice, Types.Steel};

    private void Awake()
    {
        InitCurrentLife();
        InitStatPoints();
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayName();
        DisplayBaseLife();
        DisplayCurrentLife();
        DisplayAtk();
        DisplayDef();
        DisplayStatPoints();
        DisplayWeight();
        DisplayTypes();
        DisplayWeaknesses();
        DisplayResistances();
        Debug.Log("damage = 100 and Type = Rock");
        TakeDamage(200, Types.Rock);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPokemonAlive();
    }

    // Début des différents Displays
    
    private void DisplayName()
    {
        Debug.Log("Pokemon name is " + name);
    }

    private void DisplayBaseLife()
    {
        Debug.Log("Pokemon Base life is" + BaseLife);
    }

    private void DisplayCurrentLife()
    {
        Debug.Log("Pokemon Current life is " + CurrentLife);
    }

    private void DisplayAtk()
    {
        Debug.Log("Pokemon Attack is " + Atk);
    }

    private void DisplayDef()
    {
        Debug.Log("Pokemon Defense is " + Def);
    }

    private void DisplayStatPoints()
    {
        Debug.Log("Pokemon StatPoints are " + StatPoints);
    }

    private void DisplayWeight()
    {
        Debug.Log("Pokemon Weight is" + Weight);
    }

    private void DisplayTypes()
    {
        for (int i = 0; i < types.Length; i++)
        {
            Debug.Log("Type " + (i + 1) + ": " + types[i]);
        }
    }

    private void DisplayWeaknesses()
    {
        for (int i = 0; i < Weaknesses.Length; i++)
        {
            Debug.Log("Weakness " + (i + 1) + ": " + Weaknesses[i]);
        }
    }

    private void DisplayResistances()
    {
        for (int i = 0; i < Resistances.Length; i++)
        {
            Debug.Log("Resistance " + (i + 1) + ": " + Resistances[i]);
        }
    }

    // Fin des différents Displays

    private void InitCurrentLife()
    {
        CurrentLife = BaseLife;
    }

    private void InitStatPoints()
    {
        StatPoints = BaseLife + Atk + Def;
    }

    private int GetAttackDamage()
    {
        return Atk;
    }

    private void TakeDamage(int damage, Types type)
    {
        // Regarde dans les faiblesses et les résistances pour savoir si les dégâtes doivent être modifiés
        for (int i = 0; i < Weaknesses.Length; i++)
        {
            if (Weaknesses[i] == type)
            {
                CurrentLife = Mathf.Max(0, CurrentLife - Mathf.Max(0, damage * 2));
                Debug.Log("CurrentLife = " + CurrentLife);
                return;
            }
        }

        for (int i = 0; i < Resistances.Length; i++)
        {
            if (Resistances[i] == type)
            {
                CurrentLife = Mathf.Max(0, CurrentLife - Mathf.Max(0, damage / 2));
                Debug.Log("CurrentLife = " + CurrentLife);
                return;
            }
        }

        CurrentLife = Mathf.Max(0, CurrentLife - Mathf.Max(0, damage));
        Debug.Log("CurrentLife = " + CurrentLife);
    }

    private void CheckIfPokemonAlive()
    {
        if (CurrentLife == 0)
        {
            Debug.Log(name + " is K.O...");
            return;
        } else
        {
            Debug.Log(name + " is still alive.");
        }
    }
}