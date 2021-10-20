using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    //dialogue box: character's name, dialogue
    public Text nameText;
    public Text dialogueText;

    //three buttons
    public Text option1;
    public Text option2;
    public Text defultContinue;

    //queue of sentences of 1 dialogue
    private Queue<string> sentences;

    //dialogue box animator
    public Animator dialogueBoxAnimator;

    //check if there is any dialogue to display
    public bool dialogueFinished;

    //get the dialogue array from DialogueTrigger
    public Dialogue[] dialogueArray;

    public InputDialogue dialogueFromUser;

    public int i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueFinished = false;

        dialogueArray = dialogueFromUser.dialogue;
    }

    //dialogue box showing animation
    public void dialogueAnimation()
    {
        dialogueBoxAnimator.SetBool("IsOpen", true);
    }

    //dialogue box exit animation
    public void dialogueExit()
    {
        dialogueBoxAnimator.SetBool("IsOpen", false);
    }
    
    //start the dialogue, give the character field a name, enqueue the sentences, only called by the trigger method
    public void startDialogue(Dialogue dialogue)
    {
        //show the dialoguebox
        dialogueAnimation();



        //set the name of the character
        //nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //when the dialogue box appears, it shows the first sentence
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        Debug.Log("fy is sb");
        i++;
        string finalSentence;
        // if the queue is empty, 
        if(sentences.Count == 0)
        {
            if(i == dialogueArray.Length )
            {
                dialogueExit();
                return;
            }
            else if (i < dialogueArray.Length)
            {
                foreach (string sentence in dialogueArray[i].sentences)
                {
                    //nameText.text = dialogueArray[i].name;

                    sentences.Enqueue(sentence);
                    finalSentence = sentences.Dequeue();
                }
            }
            
        }
        
        finalSentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(finalSentence));
    }



    //showing text one by one
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
