using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite _jumping;
    [SerializeField] private Sprite _standing;

    [Header("Jump settings")]
    [SerializeField] private string _jumpButton;
    [SerializeField] private float _maxJumpHeight = 1.5f; // Maximum height the character can reach
    [SerializeField] private float _jumpForce = 6f; // Force applied while the jump button is held
    [SerializeField] private float _initialGravityScale = 1.33f; // Default gravity scale
    [SerializeField] private float _fallGravityScale = 2.5f; // Gravity scale while falling
    private Rigidbody2D _rb;
    private bool _isJumping;
    private bool _jumpButtonHeld = false;
    private float _startYPosition; // Y position where the jump started in order to calculate the max height
    private int jumpTimes;
    public int JumpTimes => jumpTimes;
    private bool _allowDoubleJump = false;
    public bool AllowDoubleJump
    {
        get => _allowDoubleJump;
        set => _allowDoubleJump = value;
    }
    private int _concurrentJumpcount = 0;



    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = _initialGravityScale;
    }

    void Update()
    {
        if (Input.GetButtonDown(_jumpButton) && (!_isJumping || (_allowDoubleJump && _concurrentJumpcount < 2)))
        {
            spriteRenderer.sprite = _jumping;
            _isJumping = true;
            _jumpButtonHeld = true;
            _startYPosition = transform.position.y;
            jumpTimes++;
            _concurrentJumpcount++;
            if (_concurrentJumpcount == 2)
            {
                _allowDoubleJump = false;
            }

            
        }

        // Apply jump force while the button is held down and max height is not reached
        if (_jumpButtonHeld && _isJumping)
        {
            if (transform.position.y < _startYPosition + _maxJumpHeight)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
            else
            {
                _jumpButtonHeld = false; // Stop applying force if max height is reached
                if (_rb.gravityScale < _fallGravityScale)
                {
                    Debug.Log("gravity scale: " + _rb.gravityScale);
                    _rb.gravityScale = _fallGravityScale; // Increase gravity to make the character fall faster
                }

            }
        }

        // Stop applying force when the button is released
        if (Input.GetButtonUp(_jumpButton) && _isJumping)
        {
            _jumpButtonHeld = false;
            if (_rb.gravityScale < _fallGravityScale)
            {
                Debug.Log("gravity scale: " + _rb.gravityScale);
                _rb.gravityScale = _fallGravityScale; // Increase gravity to make the character fall faster
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            spriteRenderer.sprite = _standing;
            _isJumping = false;
            _concurrentJumpcount = 0;
            _rb.gravityScale = _initialGravityScale;
        }
    }
}
