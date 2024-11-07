using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;

public class DialogueBox : MonoBehaviour
{
    private string[] lines;
    public float textSpeed;
    public TextMeshProUGUI txtComponent;
    public TextAsset txtAsset;
    public GameObject Wizard;
    //public GameObject player;
    //private Rigidbody2D body;

    private int index;
    //private string position;
    private string path;

    private void Awake()
    {
        gameObject.SetActive(false);
        Wizard.SetActive(false);
        //gameObject.GetComponentInChildren<Renderer>().enabled = false;
        //Wizard.GetComponent<Renderer>().enabled = false;
        //body = player.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        path = AssetDatabase.GetAssetPath(txtAsset);
        txtComponent.text = string.Empty;
        ReadText();
        StartDialogue();
    }

    void Update()
    {
        //position = checkPosition();
        if (Input.GetMouseButtonDown(0))
        {
            if (txtComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                txtComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            txtComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            txtComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Wizard.SetActive(false);
        }
    }

    void ReadText()
    {
        //path = "Assets/Resources/TextFiles/test text asset.txt";
        //string path = getPath();
        StreamReader reader = new StreamReader(path);

        string line;
        string[] readlineCount;

        int count = 0;
        line = reader.ReadToEnd();
        readlineCount = line.Split("\n");
        lines = new string[readlineCount.Length];

        foreach (string s in readlineCount)
        {
            lines[count++] = s;
        }
    }
    //void setPath(string path) 
    //{ 
    //    if (gameObject.tag == "Canteen")
    //    {
    //        Debug.Log("yayayayya");
    //        this.path = "Assets/Resources/TextFiles/First Floor/canteen.txt"; 
    //    }
    //}

    //private string getPath()
    //{
    //    if (position == "Canteen")
    //    {
    //        //Debug.Log("skibidi toilet");

    //        return "Assets/Resources/TextFiles/First Floor/canteen.txt";
    //    } else
    //    {
    //        return "Assets/Resources/TextFiles/test text asset.txt";
    //    }
    //}

    //private string checkPosition()
    //{
    //    if (body.position == new Vector2(-2.996069f, -4.115806f))
    //    {
    //        turnOnAssets();
    //        return "Canteen";
    //    } else
    //    {
    //        return "skibidi";
    //    }
    //}

    //private void turnOnAssets()
    //{
    //    gameObject.GetComponent<Renderer>().enabled = true;
    //    Wizard.GetComponent<Renderer>().enabled = true;
    //}
}
