using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    public int burnDownTime = 20;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SubtractFromTimer",1f,1f); //Subtracts 1 each second
    }

    // Update is called once per frame
    void Update()
    {
        if(burnDownTime == 0)
        {
            Destroy(gameObject);
        }
    }

    void SubtractFromTimer() //Subtract 1 Each Time this method is called
    {
        burnDownTime--;
    }
}
