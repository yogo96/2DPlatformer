using System.Collections;
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
            Fall();
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

    public void Move(Vector3 direction)
    {
        Vector3 localScale = transform.localScale;

        if (direction.Equals(Vector3.right))
        {
            if (localScale.x < 0)
                transform.localScale = new Vector2(Mathf.Abs(localScale.x), localScale.y);
            transform.Translate(direction * _runSpeed * Time.fixedDeltaTime);
            _isRun = true;
        }
        else if (direction.Equals(Vector3.left))
        {
            if (localScale.x > 0)
                transform.localScale = new Vector2(localScale.x * -1, localScale.y);
            transform.Translate(direction * _runSpeed * Time.fixedDeltaTime);
            _isRun = true;
        }
        else
        {
            _isRun = false;
        }
    }

    public void Jump()
    {
        if (_groundChecker.IsGround())
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _isJump = true;
            _isRun = false;
            _isFall = false;
        }
    }

    private void Fall()
    {
        if (_rigidbody.velocity.y < 0)
        {
            _isJump = false;

            if (_groundChecker.IsGround())
            {
                _isRun = true;
                _isFall = false;
            }
            else
            {
                _isFall = true;
                _isJump = false;
            }
        }
    }
}