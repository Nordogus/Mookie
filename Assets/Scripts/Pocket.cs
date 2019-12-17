using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pocket : MonoBehaviour
{
    private GameManager gameManager;
    public Text blue;
    public Text green;
    public Text red;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager.nbResource > 0)
        {
            text.text = gameManager.nbResource.ToString();
            blue.text = gameManager.tab[0].ToString();
            green.text = gameManager.tab[1].ToString();
            red.text = gameManager.tab[2].ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
