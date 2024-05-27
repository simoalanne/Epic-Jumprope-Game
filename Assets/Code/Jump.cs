using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D _rb;
    private bool _isJumping;
    [SerializeField] private Sprite _jumping;
    [SerializeField] private Sprite _standing;
    [SerializeField] private string _jumpButton;
    // Tama tulosnayttoon
    public int jumpTimes;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(_jumpButton) && !_isJumping)
        {
            Debug.Log("dadada");


            spriteRenderer.sprite = _jumping;
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
            spriteRenderer.sprite = _standing;
            _isJumping = false;
        }
    }
}
