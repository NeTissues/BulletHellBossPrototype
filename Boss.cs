/**
*   Procedure:
*   1 - Boss lifts up until it is hovering
*   2 - Boss starts spinning
*   3 - Boss shoots basic projectiles until second phase trigger
*   4 - Second phase begins (Only damageable after mechanics are done)
*   5 - Start adding advanced projectiles to the shooting pattern
*   6 - when Boss dies, it falls to the ground
*
* 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{   
    [Header("Private Boss Settings")]
    [SerializeField] private Vector3 minHeight = new Vector3(0, 4, 0);
    [SerializeField] private Vector3 maxHeight = new Vector3(0, 5, 0);

    [SerializeField] private float minRotation = -45.0f;
    [SerializeField] private float maxRotation = 45.0f;

    [SerializeField] private float speed = 1;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hover();
        //Rotate();
    }

    /**
    *   What I'm trying to do here is use linear interpolation with Vetor3.LERP to move the boss up and down
    *   making a "hovering" effect
    *
    */
    void Hover()
    {
        t += Time.deltaTime * speed;
        // Moves the object to target position
        transform.position = Vector3.Lerp(minHeight, maxHeight, t);
        // Flip the points once it has reached the target
        if (t >= 1)
        {
            var b = maxHeight;
            var a = minHeight;
            minHeight = b;
            maxHeight = a;
            t = 0;
        }
    }

    void Rotate()
    {
        t += Time.deltaTime * speed;
        // Rotates the object to target position
        transform.Rotate(0, minRotation, 0, Space.Self);
        // Flip the points once it has reached the target
        if (t >= 1)
        {
            var b = maxRotation;
            var a = minRotation;
            minRotation = b;
            maxRotation = a;
            t = 0;
        }
    }
    
}
