using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject spriteObject;

    void Start()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteObject.SetActive(true);
        dialogueBox.SetActive(true);
        gameObject.SetActive(false);
    }
}
