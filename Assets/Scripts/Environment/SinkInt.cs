using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkInt : InteractableObject
{
    //public Animator sinkAnimator;
    //public bool isClosetOpen = true;

    public void Start()
    {
        //closetAnimator = GetComponentInParent<Animator>();
    }

    public override void Interact(Player player)
    {


        /*isClosetOpen = !isClosetOpen;
        closetAnimator.SetBool("IsClosetOpen", isClosetOpen);*/

        Debug.Log("Ќапиток смыта"); //выводит в консоль надпись о том, что напиток был вылит в раковину.


    }

}
