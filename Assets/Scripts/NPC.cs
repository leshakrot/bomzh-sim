using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public Transform[] sellers;
    public bool buying;
    private SplineFollower follower;
    private int randomDestination;
    public int destChangeCounter;
    

    private void Start()
    {
        destChangeCounter = 0;
        follower = GetComponent<SplineFollower>();
        randomDestination = Random.Range(0, sellers.Length);
    }
    // Update is called once per frame
    void Update()
    {
        if (!buying)
        {
            transform.LookAt(sellers[randomDestination], Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, sellers[randomDestination].position, 0.15f);
        }
        if(destChangeCounter > 10)
        {
            follower.follow = true;
            destChangeCounter = 0;
        }
        
    }
    public void GoShopping()
    {
        follower.follow = false;
    }
    public void SetRandomDestination()
    {
        randomDestination = Random.Range(0, sellers.Length);
    }

    public void TradeWithPlayer()
    {
        TradeManager.instance.Trade();
    }
}
