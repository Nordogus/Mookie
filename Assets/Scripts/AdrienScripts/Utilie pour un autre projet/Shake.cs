using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public float ShakeForceMultiplier;
    public Rigidbody2D[] Shaking;
    
    public void ShakingRigidBodies(Vector3 deviceAcceleration)
    {
       foreach (var rigidbody in Shaking)
        {
            rigidbody.AddForce(deviceAcceleration * ShakeForceMultiplier, ForceMode2D.Impulse);
        }
    }
}
