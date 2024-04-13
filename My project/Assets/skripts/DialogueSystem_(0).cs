using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public string[] phrases;
    public float speedText;
    public Text dialogueWindow;
    public int index;
    void Start()
    {
        dialogueWindow.text = string.Empty; 
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypePhrase());
    }

    public void NextPhrase()
    {
        if(index < phrases.Length-1)
        {
            index++;
            dialogueWindow.text = string.Empty;
            StartCoroutine(TypePhrase());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SkipText()
    {
        if(dialogueWindow.text == phrases[index])
        {
            NextPhrase();
        }
        else
        {
            StopAllCoroutines();
            dialogueWindow.text = phrases[index];
        }
    }

    IEnumerator TypePhrase()
    {
        foreach (char c in phrases[index].ToCharArray())
        {
            dialogueWindow.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }
}
