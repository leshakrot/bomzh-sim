using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public GameObject cap;
    public GameObject[] lootPrefabs;
    public Transform spawnPoint;
    public int randomCount;
    private Transform _playerTransform;
    private bool _isChecked;
    private int _counter;
    private bool _isEmpty;
    

    private void Start()
    {
        
        randomCount = Random.Range(1, 4);
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
        Instantiate(lootPrefabs[Random.Range(0, lootPrefabs.Length)], spawnPoint.position, randomRotation);
    }

    private void Update()
    {
        _playerTransform = FirstPersonController.instance.gameObject.transform;   

        if(Mathf.Abs(Vector3.Distance(transform.position, _playerTransform.position)) > 30f)
        {
            if (_isEmpty)
            {
                randomCount = Random.Range(1, 4);
                Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
                for (int i = 0; i < randomCount; i++)
                {
                    Instantiate(lootPrefabs[Random.Range(0, lootPrefabs.Length)], spawnPoint.position, randomRotation);
                }
            } 
        }
    }
    private void FixedUpdate()
    {
        _isEmpty = true;
    }

    private void OnTriggerStay(Collider other)
    {
        _isEmpty = false;
    }

    /*private void OnTriggerEnter(Collider other)
    { 
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (!_isChecked)
        {
            FindObjectOfType<MiniGame>().gameObject.transform.root.GetComponent<Camera>().enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.instance.fps.enabled = false;
        }
        _isChecked = true;
    }
    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<MiniGame>().gameObject.transform.root.GetComponent<Camera>().enabled = false;
    }

    public void CloseDumpster()
    {
        FindObjectOfType<MiniGame>().gameObject.transform.root.GetComponent<Camera>().enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.instance.fps.enabled = true;
    }*/
    /*public void OpenDumpster()
    {
        //Quaternion target = Quaternion.Euler(0, transform.rotation.y + 270, 0);
        cap.transform.localRotation = new Quaternion(0,0,0,0); //= Quaternion.Lerp(cap.transform.rotation, target, 10f);
    }*/
}
