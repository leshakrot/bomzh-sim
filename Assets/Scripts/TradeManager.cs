using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour
{
    public GameObject offerCanvas;
    public GameObject offerImage;
    public GameObject offerText;
    private int randomItemInPlayerMarketPlace;
    public int sum;
    public bool tradingProceed;
    #region Singleton
    public static TradeManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void Trade()
    {
        tradingProceed = true;
        randomItemInPlayerMarketPlace = Random.Range(0, GOInTrigger.GOinTrigger.Count);
        offerCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Player.instance.fps.enabled = false;
        offerImage.GetComponent<Image>().sprite = GOInTrigger.GOinTrigger[randomItemInPlayerMarketPlace].GetComponent<AddItemToInventory>().specificItem.itemIcon;
        sum = Mathf.RoundToInt((GOInTrigger.GOinTrigger[randomItemInPlayerMarketPlace].GetComponent<AddItemToInventory>().specificItem.price * Random.Range(0.6f, 1.5f)));
        offerText.GetComponent<TextMeshProUGUI>().text = "¡≈–” «¿ " + sum;
    }

    public void AcceptOffer()
    {
        tradingProceed = false;
        Player.instance.money += sum;
        Destroy(GOInTrigger.GOinTrigger[randomItemInPlayerMarketPlace]);
        GOInTrigger.GOinTrigger.RemoveAt(randomItemInPlayerMarketPlace);
        offerCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.instance.fps.enabled = true;
        Debug.Log(GOInTrigger.GOinTrigger.Count);
    }

    public void DeclineOffer()
    {
        tradingProceed = false;
        offerCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.instance.fps.enabled = true;
    }
}
