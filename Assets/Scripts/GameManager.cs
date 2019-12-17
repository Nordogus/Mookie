using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int forLevelUp = 10;

    public AudioManager audioManager;

    public static GameManager instance;
    public Sprite[] seasons = new Sprite[4];
    public GameObject backGround;
    public bool eggOpen;
    public int[] stomac = new int[3];
    private int sommeStomac;
    public int[] tab = new int[3];
    public int nbResource = 0;
    public int taillePocket = 10;
    public string creatureName = "";
    public int level;
    public string color = "grey";

    public int[] level0 = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        eggOpen = false;
        if (instance == null)
        {
            instance = this;
            LoadCreature();
            audioManager = AudioManager.instance;
            if (audioManager == null)
            {
                Debug.LogError("No audioManager fond in this scean.");
            }
            SceneManager.LoadScene(1);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ChoseSeason()
    {
        backGround.GetComponent<Image>().sprite = seasons[(DateTime.Now.Hour / 6) -(DateTime.Now.Hour / 6) % 1];
    }

    public bool LevelUpTest()
    {
        sommeStomac = stomac[0] + stomac[1] + stomac[2];

        if (sommeStomac >= forLevelUp + 10 * level)
        {
            LevelUp();
            return true;
        }
        return false;
    }

    public void LevelUp()
    {
        ChangColor();
        level++;
        stomac[0] = 0;
        stomac[1] = 0;
        stomac[2] = 0;
    }

    public void ChangColor()
    {
        int max = 0;
        int equalMax1 = 0;
        int equalMax2 = 0;

        for (int i = 1; i < stomac.Length; i++)
        {
            if (stomac[max] < stomac[i])
            {
                max = i;
            }
            else if (stomac[max] == stomac[i])
            {
                if (equalMax1 != 0)
                {
                    equalMax1 = i;
                }
                else
                {
                    equalMax2 = i;
                }
            }
        }

        if (equalMax2 != 0)
        {
            Debug.Log("gery");
            color = "grey"; // gris
        }
        else if (equalMax1 != 0)
        {
            if (stomac[0] == stomac[1])
            {
                Debug.Log("cyan");
                color = "cyan"; // cyan
            }
            else if (stomac[0] == stomac[2])
            {
                Debug.Log("yellow");
                color = "yellow"; // jaune
            }
            else if (stomac[1] == stomac[2])
            {
                Debug.Log("purpel");
                color = "purpel"; // violet
            }
        }
        else
        {
            Debug.Log("what");
            if (max == 0)
            {
                Debug.Log("blue");
                color = "blue"; // Rouge ou bleu ou vert
            }
            else if (max == 1)
            {
                Debug.Log("green");
                color = "green"; // Rouge ou bleu ou vert
            }
            else if (max == 2)
            {
                Debug.Log("red");
                color = "red"; // Rouge ou bleu ou vert
            }
            Debug.Log("what");
        }
        Debug.Log(max +" "+ equalMax1 + " "+ equalMax2);
    }

    public void SaveCreature()
    {
        Creature myCreature = new Creature();
        myCreature.resource = tab;
        myCreature.eggOpen = eggOpen;
        myCreature.creatureName = creatureName;
        myCreature.stomac = stomac;
        myCreature.level = level;
        myCreature.color = color;

        SaveSystem.SaveCreature(myCreature);
    }

    public void LoadCreature()
    {
        CreatureData data = SaveSystem.LoadCreature();
        
        tab = data.resource;
        nbResource = tab[0] + tab[1] + tab[2];
        eggOpen = data.eggOpen;
        creatureName = data.creatureName;
        stomac = data.stomac;
        level = data.level;
        color = data.color;
    }

    public void ResetCreature()
    {
        Creature myCreature = new Creature();
        myCreature.resource[0] = 0;
        myCreature.resource[1] = 0;
        myCreature.resource[2] = 0;
        myCreature.eggOpen = false;
        myCreature.stomac[0] = 0;
        myCreature.stomac[1] = 0;
        myCreature.stomac[2] = 0;
        myCreature.level = 0;
        myCreature.color = "grey";

        SaveSystem.SaveCreature(myCreature);
        LoadCreature();
        SceneManager.LoadScene(1);
    }
}
