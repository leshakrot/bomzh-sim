using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject[] npc;
    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 5f);
    }

    public void Spawn()
    {
        int random = Random.Range(0, npc.Length);
        Instantiate(npc[random], npc[random].transform.position, npc[random].transform.rotation);
    }
}
