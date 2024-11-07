using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class ColliderTagReturn : MonoBehaviour
{
    private string objectTag;
    public GameObject dialogueBox;
    public GameObject spriteObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //objectTag = gameObject.tag;
        //Debug.Log(objectTag);
        spriteObject.SetActive(true);
        dialogueBox.SetActive(true);
        
    }
}
