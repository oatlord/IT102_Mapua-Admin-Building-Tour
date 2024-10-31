using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StarFeedback : MonoBehaviour
{
    public Button[] starButtons;
    public Sprite filledStar;
    public Sprite emptyStar;

    int buttonIndex;
    decimal rating;

    public void isClicked()
    {
        String name = EventSystem.current.currentSelectedGameObject.name;
        //if (name.Equals("Star"))
        //{
        //    Debug.Log("0 pressed");
        //    starButtons[0].image.sprite = filledStar;
        //}
        switch (name)
        {
            case "Star 0":
                buttonIndex = 0;
                Debug.Log("0 pressed");
                changeSprite(buttonIndex);
                rating = 1.0m;
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
}
