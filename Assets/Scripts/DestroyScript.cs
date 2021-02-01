using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FirstStage" | collision.gameObject.tag == "SecondStage" | collision.gameObject.tag == "ThirdStage")
        {
            Destroy(collision.gameObject);  
        }
        
    }

    
}
