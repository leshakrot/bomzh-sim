using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal"), 0, 0); 
    }
}
