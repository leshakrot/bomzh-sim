using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpsterCloser : MonoBehaviour
{
    public GameObject cap;
    private Transform _playerTransform;
    private Transform startCapRotation;
    // Start is called before the first frame update
    void Start()
    {
        startCapRotation.rotation = cap.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        _playerTransform = FirstPersonController.instance.gameObject.transform;
        if (Mathf.Abs(Vector3.Distance(transform.position, _playerTransform.position)) > 70f)
        {
            cap.transform.rotation = startCapRotation.rotation;
        }
    }
}
