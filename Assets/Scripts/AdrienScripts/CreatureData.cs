using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreatureData
{
    public int hunger;
    public int[] resource = new int[3]; //in Red Green Blue
    public int[] stomac = new int[3];
    public bool eggOpen;
    public string creatureName;
    public int level;
    public string color;

    public CreatureData(Creature creature)
    {
        hunger = creature.hunger;
        resource = creature.resource;
        eggOpen = creature.eggOpen;
        creatureName = creature.creatureName;
        stomac = creature.stomac;
        level = creature.level;
        color = creature.color;
    }
}
