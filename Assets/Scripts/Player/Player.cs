using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //Physics
    protected Rigidbody rigidBody;


    //Data
    protected float speed = 3f;






}

public class Player : PlayerInfo
{

    void Start()
    {

        rigidBody = GetComponent<Rigidbody>(); 

    }

    void FixedUpdate()
    {

        Walk();

    }


    void Walk()
    {

        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        moveInput = Camera.main.transform.TransformDirection(moveInput);

        moveInput.y = 0;

        rigidBody.velocity = moveInput.normalized * speed; //расчёт поворота камеры засчёт умноения вводимых данных мыши xy и скорости чувствительности, предустановленной в игре

    }







}
