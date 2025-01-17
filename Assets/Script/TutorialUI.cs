using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class TutorialUI : MonoBehaviour
{
    public static TutorialUI instance;

    public Image tutorialWindow;
    public Sprite[] snakeSprites;
    public Sprite[] uTurnSprites;
    public Sprite[] r2Sprites;
    public Sprite[] trafficLightSprites;
    public Sprite[] garageSprites;
    public Sprite[] parkingSprites;
    public Sprite[] hillSprites;
    public Sprite[] freeMovementSprites;

    private Sprite[] currentSprites;
    private int currentSpriteIndex = 0;
    private int currentTutorialIndex = 0;

    void Start()
    {
        currentSprites = snakeSprites;
        tutorialWindow.sprite = currentSprites[currentSpriteIndex];
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSprite();
        }
    }

    public void SwitchToNextTutorial(Sprite[] nextSprites)
    {
        tutorialWindow.enabled = true;
        currentSprites = nextSprites;
        currentSpriteIndex = 0;
        tutorialWindow.sprite = currentSprites[currentSpriteIndex];
    }

    private void NextSprite()
    {
        if (currentSpriteIndex < currentSprites.Length - 1)
        {
            currentSpriteIndex++;
            tutorialWindow.sprite = currentSprites[currentSpriteIndex];
        }
        else
        {
            tutorialWindow.enabled = false;
        }
    }
}