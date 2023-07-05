using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int money;
    public GameObject lunch;

    public FirstPersonController fps;
    [SerializeField] private TextMeshProUGUI _moneyText;
    
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        fps = GetComponent<FirstPersonController>();
    }
    private void Update()
    {
        _moneyText.text = "Денежки: " + money.ToString();
        if (PlayerMarketZone.instance.isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerMarketZone.instance.isPlayerInMarket = !PlayerMarketZone.instance.isPlayerInMarket;
                lunch.SetActive(!PlayerMarketZone.instance.isPlayerInMarket);
                PlayerMarketZone.instance.tradeText.SetActive(false);
            }
        }
    }
}
