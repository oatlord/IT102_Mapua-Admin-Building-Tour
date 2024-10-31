using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;

public class StarFeedback : MonoBehaviour
{
    public Button[] starButtons;
    public Sprite filledStar;
    public Sprite emptyStar;

    int buttonIndex;
    decimal rating;

    public SendDataToServer sendDataToServer;
    public int feedbackValue = -1;

    void Start()
    {
        // Find the button and add a listener to it
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void isClicked()
    {
        String name = EventSystem.current.currentSelectedGameObject.name;
        switch (name)
        {
            case "Star 0":
                buttonIndex = 0;
                Debug.Log("0 pressed");
                changeSprite(buttonIndex);
                rating = 1.0m;
                Debug.Log(rating);
                break;
            case "Star 1":
                buttonIndex = 1;
                changeMultipleSprites();
                rating = 2.0m;
                break;
            case "Star 2":
                buttonIndex = 2;
                changeMultipleSprites();
                rating = 3.0m;
                break;
            case "Star 3":
                buttonIndex = 3;
                changeMultipleSprites();
                rating = 4.0m;
                break;
            case "Star 4":
                buttonIndex = 4;
                changeMultipleSprites();
                rating = 5.0m;
                break;
            default:
                break;
        }
    }

    private void changeSprite(int buttonNo)
    {
        if (starButtons[buttonNo].image.sprite == filledStar)
        {
            starButtons[buttonNo].image.sprite = emptyStar;
        } else
        {
            starButtons[buttonNo].image.sprite = filledStar;
        }
    }

    private void changeMultipleSprites()
    {
        for (int i = 0; i <= buttonIndex; i++)
        {
            changeSprite(i);
        }
    }

    public void getRating()
    {
        Test();
        Debug.Log("test");
    }

    void Test() => StartCoroutine(GetRequest_Coroutine());

    IEnumerator GetRequest_Coroutine()
    {
        string url = "https://localhost:7115/api/Feedback";
        using (UnityWebRequest www = UnityWebRequest.Get(url)) 
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Received: " + www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        } // The using block ensures www.Dispose() is called when this block is exited

    }

    private void OnButtonClick()
    {
        // Check if feedbackValue is set and valid
        if (feedbackValue >= 0)
        {
            // Call the method in SendDataToServer to send the integer
            sendDataToServer.SendIntegerToServer(feedbackValue);
        }
        else
        {
            Debug.LogError("Invalid feedback value.");
        }
    }
}
