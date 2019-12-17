using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject blueButton;
    public Text blueText;
    public GameObject greenButton;
    public Text greenText;
    public GameObject redButton;
    public Text redText;

    public GameObject feedButton;
    public GameObject travelButton;
    public GameObject retroButton;
    public GameObject pocket;
    public Text poketText;
    public InputField myName;
    public GameObject mookie;

    public GameObject back;
    public GameObject levelUp;
    public GameObject choselevel;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        myName.text = gameManager.creatureName;

        if (gameManager.eggOpen)
        {
            feedButton.SetActive(true);
            travelButton.SetActive(true);
            retroButton.SetActive(true);
        }
        else
        {
            feedButton.SetActive(false);
            travelButton.SetActive(false);
            retroButton.SetActive(false);
        }
    }

    public void ChooseLevel()
    {
        choselevel.SetActive(true);
    }

    public void CloseChooseLevel()
    {
        choselevel.SetActive(false);
    }

    public void GoTravel(int dificulty = 0) // mode balade
    {
        if (gameManager.nbResource < gameManager.taillePocket)
        {
            if (dificulty == 0)
            {
                int r = Random.Range(0, 5);
                switch (r)
                {
                    case 0:
                        SceneManager.LoadScene(2);
                        break;
                    case 1:
                        SceneManager.LoadScene(4);
                        break;
                    case 2:
                        SceneManager.LoadScene(5);
                        break;
                    case 3:
                        SceneManager.LoadScene(6);
                        break;
                    case 4:
                        SceneManager.LoadScene(7);
                        break;
                    case 5:
                        SceneManager.LoadScene(8);
                        break;
                    case 6:
                        SceneManager.LoadScene(9);
                        break;
                    case 7:
                        SceneManager.LoadScene(10);
                        break;
                    case 8:
                        SceneManager.LoadScene(11);
                        break;
                }
            }
            else if (dificulty == 1)
            {
                int r = Random.Range(5, 7);
                switch (r)
                {
                    case 0:
                        SceneManager.LoadScene(2);
                        break;
                    case 1:
                        SceneManager.LoadScene(4);
                        break;
                    case 2:
                        SceneManager.LoadScene(5);
                        break;
                    case 3:
                        SceneManager.LoadScene(6);
                        break;
                    case 4:
                        SceneManager.LoadScene(7);
                        break;
                    case 5:
                        SceneManager.LoadScene(8);
                        break;
                    case 6:
                        SceneManager.LoadScene(9);
                        break;
                    case 7:
                        SceneManager.LoadScene(10);
                        break;
                    case 8:
                        SceneManager.LoadScene(11);
                        break;
                }
            }
            else
            {
                int r = Random.Range(7, 9);
                switch (r)
                {
                    case 0:
                        SceneManager.LoadScene(2);
                        break;
                    case 1:
                        SceneManager.LoadScene(4);
                        break;
                    case 2:
                        SceneManager.LoadScene(5);
                        break;
                    case 3:
                        SceneManager.LoadScene(6);
                        break;
                    case 4:
                        SceneManager.LoadScene(7);
                        break;
                    case 5:
                        SceneManager.LoadScene(8);
                        break;
                    case 6:
                        SceneManager.LoadScene(9);
                        break;
                    case 7:
                        SceneManager.LoadScene(10);
                        break;
                    case 8:
                        SceneManager.LoadScene(11);
                        break;
                }
            }

        }
        else
        {
            //afficher que trop de resource
        }
    }

    public void FeedMode()
    {
        blueButton.SetActive(true);
        greenButton.SetActive(true);
        redButton.SetActive(true);
        back.SetActive(true);

        feedButton.SetActive(false);
        travelButton.SetActive(false);
    }

    public void OffFeedMode()
    {
        blueButton.SetActive(false);
        greenButton.SetActive(false);
        redButton.SetActive(false);
        back.SetActive(false);

        feedButton.SetActive(true);
        travelButton.SetActive(true);

        poketText.text = gameManager.nbResource.ToString();

        if (gameManager.nbResource <= 0)
        {
            pocket.SetActive(false);
        }
    }

    public void UseBlue()
    {
        if (gameManager.tab[0] > 0)
        {
            gameManager.tab[0]--;
            blueText.text = gameManager.tab[0].ToString();
            gameManager.nbResource--;
            gameManager.stomac[0]++;
            if (gameManager.LevelUpTest())
            {
                mookie.GetComponent<MookieForme>().ChooseColor();
                levelUp.SetActive(true);
            }
        }
        gameManager.SaveCreature();
    }

    public void UseGreen()
    {
        if (gameManager.tab[1] > 0)
        {
            gameManager.tab[1]--;
            greenText.text = gameManager.tab[1].ToString();
            gameManager.nbResource--;
            gameManager.stomac[1]++;
            if (gameManager.LevelUpTest())
            {
                mookie.GetComponent<MookieForme>().ChooseColor();
            }
            gameManager.SaveCreature();
            levelUp.SetActive(true);
        }
    }

    public void UseRed()
    {
        if (gameManager.tab[2] > 0)
        {
            gameManager.tab[2]--;
            redText.text = gameManager.tab[2].ToString();
            gameManager.nbResource--;
            gameManager.stomac[2]++;
            if (gameManager.LevelUpTest())
            {
                mookie.GetComponent<MookieForme>().ChooseColor();
            }
            gameManager.SaveCreature();
            levelUp.SetActive(true);
        }
    }

    public void SaveName()
    {
        gameManager.creatureName = myName.text;
        gameManager.SaveCreature();
    }

    public void ResetCreature()
    {
        gameManager.ResetCreature();
    }

    public void LoadRetro()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
