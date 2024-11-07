using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueBox : MonoBehaviour
{
    private string[] lines;
    public float textSpeed;
    public TextMeshProUGUI txtComponent;
    public TextAsset txtAsset;
    public GameObject Wizard;

    private int index;
    void Start()
    {
        txtComponent.text = string.Empty;
        ReadText();
        StartDialogue();
    }

    void Update()
    {
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
        string path = "Assets/Resources/TextFiles/test text asset.txt";
        StreamReader reader = new StreamReader(path);

        string line;
        string[] readlineCount;

        int count = 0;
        line = reader.ReadToEnd();
        readlineCount = line.Split(" ");
        lines = new string[readlineCount.Length];

        foreach (string s in readlineCount)
        {
            lines[count++] = s;
        }
    }
}
