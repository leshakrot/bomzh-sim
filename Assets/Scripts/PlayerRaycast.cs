using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private GameObject _pickImage;
    [SerializeField] private GameObject _fullSlotImage;
    private GameObject pickedObject;
    private void Start()
    {
        _pickImage.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.gameObject.CompareTag("Loot") || 
                hit.collider.gameObject.CompareTag("Bottle"))
            { 
                if (isInventorySlotAvailable())
                {
                    _pickImage.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    { 
                        Destroy(hit.collider.gameObject);
                        AddPickedItem(hit, 1);
                    }
                }

                else
                {
                    _pickImage.SetActive(false);
                    _fullSlotImage.SetActive(true);
                }

                if (Input.GetMouseButton(2))
                {
                    hit.collider.gameObject.transform.position = mousePos();
                    Vector3 oldPos = hit.collider.gameObject.transform.position;
                    Vector3 pos = mousePos();
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    hit.collider.gameObject.transform.position = ray.GetPoint(1f);
                    pickedObject = hit.collider.gameObject;
                }
                if (Input.GetMouseButtonUp(2))
                {  
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    hit.collider.gameObject.transform.position = pickedObject.transform.position;
                }
            }
            /*else if (hit.collider.gameObject.CompareTag("Dumpster"))
            {
                if (Input.GetMouseButton(0))
                {
                    hit.collider.gameObject.GetComponent<Dumpster>().OpenDumpster();
                }
            }*/
            else
            {
                if (pickedObject != null) pickedObject.GetComponent<Rigidbody>().useGravity = true;
                _pickImage.SetActive(false);
                _fullSlotImage.SetActive(false);
            }
        }
        else
        {
            if (pickedObject != null) pickedObject.GetComponent<Rigidbody>().useGravity = true;
            _pickImage.SetActive(false);
            _fullSlotImage.SetActive(false);
        }
    }

    private Vector3 mousePos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2, 1.5f));
    }

    private void AddPickedItem(RaycastHit hit, int count)
    {
        Inventory.instance.AddItem(hit.collider.gameObject.GetComponent<AddItemToInventory>().specificItem, count);
    }

    private bool isInventorySlotAvailable()
    {
        return Inventory.instance.itemList.Count < Inventory.instance.slotList.Count;
    }
}
