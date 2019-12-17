using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    int[] tableau = new int[3];
    public Text[] color;
    // Start is called before the first frame update
    void Start()
    {
        tableau[0] = 4;
        tableau[1] = 5;
        tableau[2] = 6;
    }

    // Update is called once per frame
    void Update()
    {
        color[0].text = ("couleurs :" +tableau[0]);
        color[1].text = ("couleurs :" + tableau[1]);
        color[2].text = ("couleurs :" + tableau[2]);
    }

    public void buttonVert()
    {
        tableau[0] -= 1;
        Debug.Log(tableau[0]);
    }
}
