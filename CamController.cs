using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public static int ActiveTarget = -1;
    private static bool First_Init = true;

    public float DesiredSize = .1f;
    private float factor;

    public GameObject CamBody;
    private Vector3 startcam;
    private float CamSize;

    public GameObject[] Target;
    private float OriginDistance;
    
        

    void Start()
    {
        CamSize = CamBody.GetComponent<Camera>().orthographicSize;
        startcam = CamBody.transform.position;
          
    }

    
    void Update()
    {
        if (ActiveTarget != -1)
        {
            
            if (First_Init)
            {
                OriginDistance = Vector3.Distance(CamBody.transform.position, Target[ActiveTarget].transform.position);

                First_Init = !First_Init;
            }
                        
            float CurrentDistance = Vector3.Distance(CamBody.transform.position, Target[ActiveTarget].transform.position);

            if (OriginDistance == 0) OriginDistance = CamSize - DesiredSize;

            factor = 1 - (CurrentDistance / OriginDistance);

            CamBody.GetComponent<Camera>().orthographicSize = CamSize - ((CamSize - DesiredSize) * factor);
            

            float dy = Target[ActiveTarget].transform.position.y - CamBody.transform.position.y;
            float dx = Target[ActiveTarget].transform.position.x - CamBody.transform.position.x;
            if (ActiveTarget != -1) CamBody.transform.position = Vector3.MoveTowards(CamBody.transform.position, Target[ActiveTarget].transform.position, .1f);
          
        }
    }

    public void rstt()
    {
        ActiveTarget = -1;
        CamBody.transform.position = startcam;
        CamBody.GetComponent<Camera>().orthographicSize = CamSize;
        First_Init = true;
    }

}
