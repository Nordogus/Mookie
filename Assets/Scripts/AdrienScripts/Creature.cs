using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature
{
    public int red =0;
    public int green = 0;
    public int blue = 0;
    public int hunger = 0;
    public int[] resource  = new int[3] {0, 0, 0};
    public int[] stomac = new int[3] { 0, 0, 0 };
    public string color = "grey";
    public bool eggOpen = false;
    public string creatureName = "";
    public int level;

    public void SaveCreature()
    {
        SaveSystem.SaveCreature(this);
    }

    public void LoadCreature()
    {
        CreatureData data = SaveSystem.LoadCreature();

        hunger = data.hunger;
        resource = data.resource;
        eggOpen = data.eggOpen;
        creatureName = data.creatureName;
        stomac = data.stomac;
        level = data.level;
    }

    public void buttonVert()
    {
        green -= 1;
        Debug.Log(green);
    }
}
