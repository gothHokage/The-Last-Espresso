using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreezeInt : InteractableObject
{

    public Animator freezeAnimator;
    public bool isFreezeOpen = true;

    public void Start()
    {
        freezeAnimator = GetComponentInParent<Animator>();
    }

    public override void Interact(Player player)
    {


        isFreezeOpen = !isFreezeOpen;
        freezeAnimator.SetBool("IsFreezeOpen", isFreezeOpen);


    }


}