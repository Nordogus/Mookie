using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoltManager : MonoBehaviour
{
    public List<GameObject> colorTypes = new List<GameObject>();
    public List<GameObject> colors = new List<GameObject>();
    public int listLimite = 10;

    public int nbMinColor = 4;
    public int nbMaxColor = 16;

    public Vector2 sizeMap = new Vector2(10, 10);

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in colorTypes)
        {
            int nbColorOftype = Random.Range(nbMinColor, nbMaxColor);

            for (int i = 0; i < nbColorOftype; i++)
            {
                GameObject myObj;
                myObj = Instantiate(item);
                myObj.transform.position = new Vector2(Random.Range(-sizeMap.x, sizeMap.x), Random.Range(-sizeMap.y, sizeMap.y));
            }
        }
    }
}
