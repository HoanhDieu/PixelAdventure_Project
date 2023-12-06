using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnPlayerTriggerEnter();
        }
    }

    protected virtual void OnPlayerTriggerEnter()
    {
        
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnPlayerTriggerExit();
        }
    }

    protected virtual void OnPlayerTriggerExit()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnPlayerCollisionEnter();
        }
    }

    protected virtual void OnPlayerCollisionEnter()
    {
        
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            OnPlayerCollisionExit();
        }
    }

    protected virtual void OnPlayerCollisionExit()
    {
        
    }
}
