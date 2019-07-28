using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int ID;

    private void OnMouseDown()
    {

       
    CamController.ActiveTarget = ID;
   


    }
}

