using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueBox;

    [SerializeField]
    private AudioSource buttonSound;

    public Text dialogueText;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);//добавляем в очередь предложения
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        buttonSound.Play();

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();//удаляем предложения из очереди
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
    }

    public void EndDialogue()
    {
        buttonSound.Play();
        dialogueBox.SetActive(false);
    }
}
