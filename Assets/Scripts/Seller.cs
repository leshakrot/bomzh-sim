using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    private bool buying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            buying = true;
            other.gameObject.GetComponent<Animator>().SetBool("walk", false);
            other.gameObject.GetComponent<NPC>().destChangeCounter++;
            if (gameObject.CompareTag("PlayerMarketplace") && 
                PlayerMarketZone.instance.isPlayerInMarket && 
                GOInTrigger.GOinTrigger.Count > 0 &&
                !TradeManager.instance.tradingProceed)
            {
                other.gameObject.GetComponent<NPC>().TradeWithPlayer();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            other.gameObject.GetComponent<NPC>().buying = buying;
            StartCoroutine(ThinkWhatToBuy());
            other.gameObject.GetComponent<NPC>().buying = buying;
            other.gameObject.GetComponent<NPC>().SetRandomDestination();
            //other.gameObject.GetComponent<Animator>().SetBool("walk", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("walk", true);
            //buying = false;
        }
    }

    IEnumerator ThinkWhatToBuy()
    {
        yield return new WaitForSeconds(Random.Range(10, 20));
        buying = false;
    }
}
