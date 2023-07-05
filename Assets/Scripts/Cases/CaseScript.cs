using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseScript : MonoBehaviour
{
    public bool isCaseOpened;
    public GameObject[] prefabs;
    public GameObject scrollPanel;
    public float scrollSpeed = -200f;
    private float velocity = 400f;
    public Sprites[] sprites;
    public Image[] imagePrefabs;
    public Sprite finalSprite;

    private void Start()
    {
        
    }

    void Update()
    {
        if (isCaseOpened)
        {
            scrollSpeed = Mathf.MoveTowards(scrollSpeed, 0, velocity * Time.deltaTime);
            RaycastHit2D hit = Physics2D.Raycast(Vector2.down, Vector2.up);
            Debug.Log(scrollSpeed);
            if(hit.collider != null)
            {
                if (scrollSpeed == 0)
                {
                    finalSprite = hit.collider.gameObject.GetComponent<Image>().sprite;
                    //Inventory.instance.AddItem(hit.collider.gameObject.GetComponent<Image>().sprite.);
                    Debug.Log(finalSprite.name);
                }
            } 
            else if (scrollSpeed == 0)
            {
                scrollSpeed = Mathf.MoveTowards(scrollSpeed, -200f, velocity * Time.deltaTime);
            }
        }
    }

    public void StartRoll()
    {
        isCaseOpened = true;
        SimulateCases();
        velocity = Random.Range(300f, 400f);
    }


    public void SimulateCases()
    {
        for(int i = 0; i < 40; i++)
        {
            int rand = Random.Range(0, 1000);
            int randWeapon = 0;

            if(rand <= 600)
            {
                randWeapon = 0;
                imagePrefabs[randWeapon].sprite = sprites[0].white[Random.Range(0, sprites[0].white.Length)];
            }
            else if (rand > 600 && rand <= 900)
            {
                randWeapon = 1;
                imagePrefabs[randWeapon].sprite = sprites[0].blue[Random.Range(0, sprites[0].blue.Length)];
            }
            else if (rand > 900 && rand <= 990)
            {
                randWeapon = 2;
                imagePrefabs[randWeapon].sprite = sprites[0].purple[Random.Range(0, sprites[0].purple.Length)];
            }
            else if (rand > 990)
            {
                randWeapon = 3;
                imagePrefabs[randWeapon].sprite = sprites[0].yellow[Random.Range(0, sprites[0].yellow.Length)];
            }

            GameObject obj = Instantiate(prefabs[randWeapon], new Vector2(0, 0), Quaternion.identity) as GameObject;
            obj.transform.SetParent(scrollPanel.transform);
            obj.transform.localScale = new Vector2(1, 1);
        }
    }
}
