using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RopeEvents : MonoBehaviour
{
    [SerializeField] float _ropeSpeed;
    [SerializeField] BoxCollider2D ropeCollider;
    [SerializeField] Animator animator;
    [SerializeField] GameObject _rope;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void DisableCollider()
    {
        ropeCollider.enabled = false;
    }

    private void EnableCollider()
    {
        ropeCollider.enabled = true;
    }

    private void fastenRope()
    {
        if (_ropeSpeed < 2.5f) { 
            _ropeSpeed += 0.02f;
            animator.speed = _ropeSpeed;
        }
    }

    private void ropeLayerUp()
    {
        _rope.layer++;
    }

    private void ropeLayerDown()
    {
        _rope.layer--;
    }
}
