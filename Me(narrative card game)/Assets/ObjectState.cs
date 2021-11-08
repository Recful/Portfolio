using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectState : MonoBehaviour
{
    
    public PickUp pickUpClass;
    public GameObject AmyInteractable1;
    public GameObject AmyInteractable2;
    public GameObject pickUpInteractable;
    public DialogueManager conversationState;
    public bool hasEssential = false;
    public bool hasSpoken = false;

    // Start is called before the first frame update
    void Start()
    {
        AmyInteractable2.SetActive(false);
    }

    void Update()
    {
        if(conversationState.endConversation == true)
        {
            hasSpoken = true;
            disableAmyInteractable();
        }

        if(pickUpClass.haveItem == true)
        {
            hasEssential = true;
            disablePickUp();
        }

    }
    public void disableAmyInteractable()
    {
        if(hasSpoken == true)
        {
            AmyInteractable1.SetActive(false);
            AmyInteractable2.SetActive(true);
        }
    }

    public void disablePickUp()
    {
        if(hasEssential == true)
        {
            pickUpInteractable.SetActive(false);
        }
    }
}
