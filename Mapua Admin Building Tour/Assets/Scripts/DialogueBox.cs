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

    private int index;
    private string path;
    private string texts;

    public bool isOpeningDialogue;

    private void Awake()
    {
        if (isOpeningDialogue == true)
        {
            gameObject.SetActive(true);
            Wizard.SetActive(true);
            //isOpeningDialogue = false;
        } else
        {
            gameObject.SetActive(false);
            Wizard.SetActive(false);
        }
    }
    void Start()
    {
        //path = AssetDatabase.GetAssetPath(txtAsset);
        texts = txtAsset.ToString();
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
            if (isOpeningDialogue == true)
            {
                Destroy(gameObject);
                Destroy(Wizard);
            }
        }
    }

    void ReadText()
    {
        //StreamReader reader = new StreamReader(path);

        //string line;
        string[] readlineCount;

        int count = 0;
        //line = reader.ReadToEnd();
        //readlineCount = line.Split("\n");
        readlineCount = texts.Split("\n");
        lines = new string[readlineCount.Length];

        foreach (string s in readlineCount)
        {
            lines[count++] = s;
        }
    }
}
