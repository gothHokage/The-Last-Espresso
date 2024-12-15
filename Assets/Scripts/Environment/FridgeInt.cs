using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FridgeInt : InteractableObject
{

    public Animator fridgeAnimator;
    public bool isFridgeOpen = true;

    public void Start()
    {
        fridgeAnimator = GetComponentInParent<Animator>();
    }

    public override void Interact(Player player)
    {


        isFridgeOpen = !isFridgeOpen;
        fridgeAnimator.SetBool("IsFridgeOpen", isFridgeOpen);


    }


}