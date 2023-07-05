using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOInTrigger : MonoBehaviour
{
    public static List<GameObject> GOinTrigger = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Loot"))
        {
            GOinTrigger.Add(other.gameObject);
            Debug.Log("List++");
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Loot"))
        {
            GOinTrigger.Remove(other.gameObject);
            Debug.Log("List--");
        }      
    }
}
