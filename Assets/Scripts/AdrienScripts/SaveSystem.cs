using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{

    public static void SaveCreature(Creature creature)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/creature.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        CreatureData data = new CreatureData(creature);
        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static CreatureData LoadCreature()
    {

        string path = Application.persistentDataPath + "/creature.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CreatureData data = formatter.Deserialize(stream) as CreatureData;
            stream.Close();
            return data;
        }
        else
        {
            SaveCreature(new Creature());
            return LoadCreature();
        }
    }
}
