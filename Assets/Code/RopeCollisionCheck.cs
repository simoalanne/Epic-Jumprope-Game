using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RopeCollisionCheck : MonoBehaviour
{
    private Collider2D _collider;
    // Start is called before the first frame update
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with rope");
            // TODO: endGame();
            /*
             * timescale nollaan
             * Enabloi tulosnaytto
             */
        }
    }
}
