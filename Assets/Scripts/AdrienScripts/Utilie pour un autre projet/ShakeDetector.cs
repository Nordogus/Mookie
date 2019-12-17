using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Shake))]
public class ShakeDetector : MonoBehaviour
{
    public float maxTime =5f;
    float timeleft;
    public float ShakeDetection;
    public float MinShakeInterval;

    private float sqrShakeDetectionThresold;
    private float timeSinceLastShake;
    private bool IfShake;
    private Shake Shaker;

    public GameObject Texte;

    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionThresold = Mathf.Pow(ShakeDetection, 2);
        Shaker = GetComponent<Shake>();
        timeleft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= sqrShakeDetectionThresold && Time.unscaledTime>= timeSinceLastShake +MinShakeInterval)
        {
            Shaker.ShakingRigidBodies(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;
            IfShake = true;

        }
        if (IfShake == true)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;

            }
            else
            {
                Texte.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
