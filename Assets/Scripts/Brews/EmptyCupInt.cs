using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCupInt : InteractableObject
{
    //public Animator closetAnimator;
    //public bool isClosetOpen = true;

    public void Start()
    {
        //closetAnimator = GetComponentInParent<Animator>();
    }

    public override void Interact(Player player)
    {


        /*isClosetOpen = !isClosetOpen;
        closetAnimator.SetBool("IsClosetOpen", isClosetOpen);*/

        Debug.Log("Пустой стакан взят");
    }
}
