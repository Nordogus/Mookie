using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MookieForme : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject buttonManager;

    public Sprite egg;
    public Sprite[] colors = new Sprite[10];

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (!gameManager.eggOpen)
        {
            GetComponent<Image>().sprite = egg;
        }
        else
        {
            ChooseColor();
        }
    }

   public void OpenEgg()
    {
        gameManager.color = "grey";
        if (!gameManager.eggOpen)
        {
            ChooseColor();
            gameManager.eggOpen = true;
            //gameManager.audioManager.PlaySound("OpenEgg");

            buttonManager.GetComponent<ButtonManager>().feedButton.SetActive(true);
            buttonManager.GetComponent<ButtonManager>().travelButton.SetActive(true);
            buttonManager.GetComponent<ButtonManager>().retroButton.SetActive(true);

            gameManager.SaveCreature();
        }
        
    }

    public void ChooseColor()
    {
        if (gameManager.color == "blue")
        {
            GetComponent<Image>().sprite = colors[0];
        }
        else if (gameManager.color == "green")
        {
            GetComponent<Image>().sprite = colors[1];
        }
        else if (gameManager.color == "red")
        {
            GetComponent<Image>().sprite = colors[2];
        }
        else if (gameManager.color == "grey")
        {
            GetComponent<Image>().sprite = colors[3];
        }
        else if (gameManager.color == "purpel")
        {
            GetComponent<Image>().sprite = colors[4];
        }
        else if (gameManager.color == "cyan")
        {
            GetComponent<Image>().sprite = colors[5];
        }
        else if (gameManager.color == "yellow")
        {
            GetComponent<Image>().sprite = colors[6];
        }
    }
}
