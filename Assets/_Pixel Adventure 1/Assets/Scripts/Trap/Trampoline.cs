using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;
    [SerializeField] private float compressDelay = 2f;
    [SerializeField] private Animator anim;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            anim.SetBool("hasPlayer", true);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Compress());
        }
    }
    
    private IEnumerator Compress()
    {
        yield return new WaitForSeconds(compressDelay);
        anim.SetBool("hasPlayer", false);
    }
}
