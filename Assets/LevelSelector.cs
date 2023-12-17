using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI subjectUI;
    [SerializeField] GameObject previousSubjectArrow;
    [SerializeField] GameObject nextSubjectArrow;

    public Button[] levelButtons;
    public CloudSave cloudSave;
    string[] subject = { "English", "Mathematic", "Science", "Geography", "History" };

    void Start()
    {
        cloudSave.RetrieveAllKeys();
        subjectUI.text = subject[0];
        loadLevelData();
        previousSubjectArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    async void loadLevelData()
    {

        print("subject ui: " + subjectUI.text);

        int levelReached = await cloudSave.LoadData(subjectUI.text);

        print("Level reached: " + levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if ((i + 1) > levelReached)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }

        }
    }

    // function to change text to previous subject
    public void changeToPreviousSubject()
    {
        // get current index of subject
        int currentIndex = Array.IndexOf(subject, subjectUI.text);

        Debug.Log("Current Index: " + currentIndex);

        // make new index subtract 1 to change to previous subject
        int newIndex = currentIndex - 1;

        // if current subject is mathematic (before first subject), change to previous subject
        // and make previous button invisible
        if (newIndex == 0)
        {
            subjectUI.text = subject[newIndex];
            previousSubjectArrow.SetActive(false);
        }

        // if current subject is history (final subject), change to previous subject
        // and make next button visible
        else if (currentIndex == (subject.Length - 1))
        {
            subjectUI.text = subject[newIndex];
            nextSubjectArrow.SetActive(true);
        }

        // change text to previous subject
        else
        {
            subjectUI.text = subject[newIndex];
        }

        loadLevelData();

    }

    // function to change text to next subject
    public void changeToNextSubject()
    {
        // get current index of subject
        int currentIndex = Array.IndexOf(subject, subjectUI.text);

        Debug.Log("Current Index: " + currentIndex);

        // make new index add 1 to change to next subject
        int newIndex = currentIndex + 1;

        // if current subject is english, change text to next subject
        // and make previous button visible
        if (currentIndex == 0)
        {
            subjectUI.text = subject[newIndex];
            previousSubjectArrow.SetActive(true);
        }

        // if current subject is geography (before last subject), change text to next subject
        // and make next button invisible
        else if (newIndex == (subject.Length - 1))
        {
            subjectUI.text = subject[newIndex];
            nextSubjectArrow.SetActive(false);
        }

        // change text to next subject
        else
        {
            subjectUI.text = subject[newIndex];
        }

        loadLevelData();
    }
}