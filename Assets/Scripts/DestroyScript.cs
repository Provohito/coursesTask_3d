using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "destroyObject")
        {
            Destroy(collision.gameObject);  
        }
        
    }

    
}
