using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLItter : MonoBehaviour
{
    public GameObject Litter;

    public float speed = 4;
    public Vector2 vc2;

    public void Update()
    {
        Litter.transform.Translate(-vc2 * speed * Time.deltaTime);
        speed += 0.00001f;

        if (Litter.transform.position.y < -6.11f)
        {
            Destroy(Litter);
        }
    }
}