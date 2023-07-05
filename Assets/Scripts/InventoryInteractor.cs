using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteractor : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryCanvas;
    private void Update()
    {
        #region Inventory

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _inventoryCanvas.gameObject.SetActive(!_inventoryCanvas.activeSelf);

            if (_inventoryCanvas.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        #endregion
    }
}
