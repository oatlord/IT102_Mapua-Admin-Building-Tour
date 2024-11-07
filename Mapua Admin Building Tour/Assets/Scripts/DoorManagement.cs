using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagement : MonoBehaviour
{
    public BoxCollider2D[] boxColliders;

    void Start()
    {

    }
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (BoxCollider2D boxCollider in boxColliders)
        {
            if (boxCollider.enabled == true)
            {
                boxCollider.enabled = false;
            } else
            {
                boxCollider.enabled = true;
            }
        }
    }
}
