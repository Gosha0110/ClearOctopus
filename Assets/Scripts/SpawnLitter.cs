using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLitter : MonoBehaviour
{
    public GameObject[] Litters;

    public Transform Spawner;
    private int randomLitter;

    private int randomMove;

    public Transform[] MovePos;

    public void Start()
    {
        StartCoroutine(SpawnCD());
    }

    public void FixedUpdate()
    {
        Spawner.position = MovePos[randomMove].position;
    }

    public void Repeat()
    {
        StartCoroutine(SpawnCD());
    }

    public IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(0.75f);
        randomMove = Random.Range(0, MovePos.Length);
        randomLitter = Random.Range(0, 5);
        Instantiate(Litters[randomLitter], Spawner.position, Quaternion.identity);
        Repeat();
    }
}