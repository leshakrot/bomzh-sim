using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehShop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _shop.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.instance.fps.enabled = false;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VehShopExit();
        }
    }

    public void VehShopExit()
    {
        _shop.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.instance.fps.enabled = true;
    }
}
