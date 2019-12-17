using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Text_Manager : MonoBehaviour
{
    private GameManager gameManager;
    public Text[] retro;
    public GameObject Couleur_animal;
    public Sprite Grey;
    public Sprite Red;
    public Sprite Blue;
    public Sprite Green;
    public Sprite Purple;
    public Sprite Cyan;
    public Sprite Yellow;
    private string color_button;

    public Text blue;
    public Text green;
    public Text red;
    public Text bluehist;
    public Text greenhist;
    public Text redhist;
    public Text Historique1;
    public GameObject Fruit_historique1;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        SetText();
    }
    
    private void SetText()
    {
        retro[0].text = gameManager.creatureName;
        retro[1].text = "Repartition des couleurs";
        retro[2].text = ("Niveau : " + gameManager.level);
        retro[3].text = "Historique";
        color_button = gameManager.color;

        if (retro[0].text == "")
        {
            retro[0].text = "Mookie";
        }
        if (color_button == "red")
        {
            Couleur_animal.GetComponent<Image>().sprite = Red;
            retro[4].text = "Rouge";
            retro[5].text = "Dynamique, facile à mettre en colère";
        }
        else if(color_button == "blue")
        {
            Couleur_animal.GetComponent<Image>().sprite = Blue;
            retro[4].text = "Bleu";
            retro[5].text = "Sympathie, calme, confiance, passivité";
        }
        else if (color_button == "green")
        {
            Couleur_animal.GetComponent<Image>().sprite = Green;
            retro[4].text = "Vert";
            retro[5].text = "Endurance, sérénité, paresseux";
        }
        else if (color_button == "grey")
        {
            Couleur_animal.GetComponent<Image>().sprite = Grey;
            retro[4].text = "Gris";
            retro[5].text = "Neutralité, élégance, indécision, douceur";
        }
        else if (color_button == "purple")
        {
            Couleur_animal.GetComponent<Image>().sprite = Purple;
            retro[4].text = "Violet";
            retro[5].text = "Error";
        }
        else if (color_button == "yellow")
        {
            Couleur_animal.GetComponent<Image>().sprite = Yellow;
            retro[4].text = "Violet";
            retro[5].text = "Error";
        }
        else if (color_button == "cyan")
        {
            Couleur_animal.GetComponent<Image>().sprite = Cyan;
            retro[4].text = "Cyan";
            retro[5].text = "Error";
        }

        blue.text = gameManager.stomac[0].ToString();
        green.text = gameManager.stomac[1].ToString();
        red.text = gameManager.stomac[2].ToString();
       
    }


    public void Retour()
    {
        SceneManager.LoadScene(1);
    }
}
