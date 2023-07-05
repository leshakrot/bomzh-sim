using UnityEngine;

public class SpawnBottles : MonoBehaviour
{
    [SerializeField] private GameObject[] _bottles;
    private Transform _playerTransform;
    private bool _isEmpty;

    private void Start()
    {
        Instantiate(_bottles[Random.Range(0, _bottles.Length)], transform.position, transform.rotation);
    }
    private void Update()
    {
        _playerTransform = FirstPersonController.instance.gameObject.transform;
        if (_isEmpty && Mathf.Abs(Vector3.Distance(transform.position, _playerTransform.position)) > 70f)
        {
            Instantiate(_bottles[Random.Range(0, _bottles.Length)], transform.position, transform.rotation);
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
}
