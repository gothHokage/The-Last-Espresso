using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{


    public Transform playerRotation;
    public Transform candleRotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 targetPosition = new Vector3(playerRotation.position.x, candleRotation.position.y, playerRotation.position.z);

        candleRotation.LookAt(targetPosition);


    }
}
