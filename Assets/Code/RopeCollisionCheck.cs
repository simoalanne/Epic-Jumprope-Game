using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class RopeCollisionCheck : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private GameObject _targetRope;
    [SerializeField] private GameObject _endMenu;

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
            _endMenu.SetActive(true);
            
            Destroy(_targetRope);
            int getScore = (int)FindObjectOfType<Jump>().JumpTimes;
            FindObjectOfType<DisplayScore>().displayScore(getScore);
        }
    }
}
