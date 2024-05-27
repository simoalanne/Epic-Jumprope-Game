using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Animation _jumpAnim;
    private Rigidbody2D _rb;
    private bool _isJumping;
    // Tama tulosnayttoon
    public int jumpTimes;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isJumping)
        {
            Debug.Log("dadada");

            // _jumpAnim.Play();
            _rb.velocity = new Vector2(0, 5f);
            _isJumping = true;
            jumpTimes++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("collided");
            _isJumping = false;
        }
    }
}
