using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public CaseScript caseScript;

    void Update()
    {
        if(caseScript.isCaseOpened) gameObject.transform.Translate(new Vector2(caseScript.scrollSpeed, 0) * Time.deltaTime);
    }
}
