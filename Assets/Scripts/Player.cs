using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Vector2 sizeMap = new Vector2(10, 10);
    private bool playerOut = false;
    private Animator anim;

    public List<Text> texts;
    public Text nbInPocket;
    public Text maxInPocket;

    public GameObject uiEnd;
    public GameObject backButton;
    public GameObject uiLevel;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        uiEnd.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
        inPocket();
        ColorAnim();
        texts[0].text = gameManager.tab[0].ToString();
        texts[1].text = gameManager.tab[1].ToString();
        texts[2].text = gameManager.tab[2].ToString();
        maxInPocket.text = gameManager.taillePocket.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.nbResource < gameManager.taillePocket)
        {
            Move();
        }
        
    }

    void Move()
    {
        if (transform.position.x > sizeMap.x)
        {
            transform.position = new Vector3(sizeMap.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -sizeMap.x)
        {
            transform.position = new Vector3(-sizeMap.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y > sizeMap.y)
        {
            transform.position = new Vector3(transform.position.x, sizeMap.y, transform.position.z);
        }
        else if (transform.position.y < -sizeMap.y)
        {
            transform.position = new Vector3(transform.position.x, -sizeMap.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PickUp>() != null)
        {
            Debug.Log("");
            if (gameManager.nbResource < gameManager.taillePocket)
            {
                switch (collision.GetComponent<PickUp>().color)
                {
                    case "blue":
                        gameManager.tab[0]++;
                        texts[0].text = gameManager.tab[0].ToString();
                        gameManager.audioManager.PlaySound("collect1");
                        break;
                    case "green":
                        gameManager.tab[1]++;
                        texts[1].text = gameManager.tab[1].ToString();
                        gameManager.audioManager.PlaySound("collect2");
                        break;
                    case "red":
                        gameManager.tab[2]++;
                        texts[2].text = gameManager.tab[2].ToString();
                        gameManager.audioManager.PlaySound("collect3");
                        break;
                }

                gameManager.nbResource++;
                inPocket();
                if (gameManager.nbResource >= gameManager.taillePocket)
                {
                    uiEnd.SetActive(true);
                    uiLevel.SetActive(false);
                }
                collision.GetComponent<PickUp>().Destruct();
            }
        }
        if (collision.gameObject.tag == "Home" && playerOut)
        {
            gameManager.SaveCreature();
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Home")
        {
            playerOut = true;
        }
    }

    private void inPocket()
    {
        nbInPocket.text = gameManager.nbResource.ToString();
    }

    public void EndTravel()
    {
        gameManager.SaveCreature();
        SceneManager.LoadScene(1);
    }

    public void ColorAnim()
    {
        if (gameManager.color == "grey")
        {
            anim.SetInteger("color", 0);
        }
        else if(gameManager.color == "blue")
        {
            anim.SetInteger("color", 1);
        }
        else if (gameManager.color == "green")
        {
            anim.SetInteger("color", 2);
        }
        else if (gameManager.color == "red")
        {
            anim.SetInteger("color", 3);
        }
        else if (gameManager.color == "cyan")
        {
            anim.SetInteger("color", 4);
        }
        else if (gameManager.color == "purpel")
        {
            anim.SetInteger("color", 5);
        }
        else if (gameManager.color == "yellow")
        {
            anim.SetInteger("color", 6);
        }
    }
}
