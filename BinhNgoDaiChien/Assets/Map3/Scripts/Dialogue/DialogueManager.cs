using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public static bool combat = false;

    //health Bar Boss
    public Slider HealthBarBoss;
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded messages: "+messages.Length);
        DisplayMessage();

        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        //messageText.text = messageToDisplay.message;

        // begin animation message

        StartCoroutine(AnimationTextAppear(messageToDisplay.message));

        //end animation message


        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation eneded!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();

            isActive = false;

            combat = true;
            HealthBarBoss.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().Play("Idle");
        }
    }

    IEnumerator AnimationTextAppear(string message)
    {
        char[] charArr = message.ToCharArray();

        messageText.text = "";
        foreach (char letter in charArr)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            NextMessage();
        }
    }
}
