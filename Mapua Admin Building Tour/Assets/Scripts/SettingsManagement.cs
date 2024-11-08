using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SettingsPanel;
    private void Awake()
    {
        SettingsPanel.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSettingsButton()
    {
        if (SettingsPanel.activeSelf == false)
        {
            SettingsPanel.SetActive(true);
        } else
        {
            SettingsPanel.SetActive(false);
        }
    }

    public void ClickResumeButton()
    {
        SettingsPanel.SetActive(false);
    }

    public void ClickQuitButton()
    {
        SceneManager.LoadScene("Feedback Screen");
    }
}
