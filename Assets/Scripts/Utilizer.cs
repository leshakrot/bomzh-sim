using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilizer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
            Player.instance.money += other.gameObject.GetComponent<AddItemToInventory>().specificItem.price;
            Destroy(other.gameObject);
        }
    }
}
