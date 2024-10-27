using UnityEngine;
using TMPro;
using System;

public class SearchManager : MonoBehaviour
{
    public GameObject searchBar;
    public GameObject player;
    Vector2 target;
    float step;

    // Start is called before the first frame update
    void Start()
    {
        step = 2f * Time.deltaTime;
    }

    // Update is called once per frame  
    public void Search()
    {
        string searchTxt = searchBar.GetComponent<TMP_InputField>().text;
        if (searchTxt.Equals("Canteen"))
        {
            Debug.Log("yippee");
            target = new Vector2(-2.996069f, -4.115806f);
            player.transform.position = Vector2.MoveTowards(player.transform.position, target, step);
        }
    }
}
