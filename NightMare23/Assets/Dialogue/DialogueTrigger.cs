using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    private AudioSource buttonSound;

    public void TriggerDialogue()
    {
        buttonSound.Play();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
