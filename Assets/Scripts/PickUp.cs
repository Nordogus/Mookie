using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string color;

    public void Destruct()
    {
        // cree un effect

        Destroy(gameObject);
    }
}
