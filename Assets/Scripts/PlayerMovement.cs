using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 0.5f;
    [SerializeField] private float _jumpForce = 9f;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private bool _isJump;
    private bool _isFall;
    private bool _isRun;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        Jump();
    }
    
    public bool IsJump()
    {
        return _isJump;
    }
    
    public bool IsFall()
    {
        return _isFall;
    }
    
    public bool IsRun()
    {
        return _isRun;
    }
    
    private void Move()
    {
        float axisHorizontal = Input.GetAxis("Horizontal");
        Vector3 localScale = transform.localScale;

        if (axisHorizontal > 0)
        {
            if (localScale.x < 0)
                transform.localScale = new Vector2(Mathf.Abs(localScale.x), localScale.y);
            transform.Translate(Vector3.right * _runSpeed * Time.fixedDeltaTime);
            _isRun = true;
        }
        else if (axisHorizontal < 0)
        {
            if (localScale.x > 0)
                transform.localScale = new Vector2(localScale.x * -1, localScale.y);
            transform.Translate(Vector3.left * _runSpeed * Time.fixedDeltaTime);
            _isRun = true;
        }
        else
        {
            _isRun = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGround())
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _isJump = true;
            _isRun = false;
            _isFall = false;
        }
        else if (_groundChecker.IsGround() == false && _rigidbody.velocity.y > 0)
        {
            _isJump = true;
            _isRun = false;
            _isFall = false;
        }
        else if (_groundChecker.IsGround() == false && _rigidbody.velocity.y < 0)
        {
            _isFall = true;
            _isRun = false;
            _isJump = false;
        }
        else if (_groundChecker.IsGround())
        {
            _isJump = false;
            _isFall = false;
        }
    }
}
