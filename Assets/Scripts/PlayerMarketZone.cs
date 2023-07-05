using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarketZone : MonoBehaviour
{
    public bool isPlayerInMarket;
    public bool isPlayerInTrigger;
    public GameObject tradeText;
    

    #region Singleton
    public static PlayerMarketZone instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tradeText.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tradeText.SetActive(false);
            isPlayerInMarket = false;
            isPlayerInTrigger = false;
        }
    }
}
