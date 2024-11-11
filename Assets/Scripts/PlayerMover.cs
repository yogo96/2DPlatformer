using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 0.5f;
    [SerializeField] private float _jumpForce = 9f;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private int _rotateDegrees = 180;
    private int _rotateZeroDegrees = 0;
    private bool _isJump;
    private bool _isFall;
    private bool _isRun;
    private Coroutine _fallingCoroutine;

    public bool IsJump => _isJump;

    public bool IsFall => _isFall;

    public bool IsRun => _isRun;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        if (_fallingCoroutine != null)
            StopCoroutine(_fallingCoroutine);
    }

    public void Move(Vector3 direction)
    {
        if (direction.Equals(Vector3.zero))
        {
            _isRun = false;
        }
        else
        {
            float _rotate = 0;
            if (direction.Equals(Vector3.left))
            {
                _rotate = _rotateDegrees;
            }

            transform.rotation = Quaternion.Euler(_rotateZeroDegrees, _rotate, _rotateZeroDegrees);
            transform.Translate(Vector3.right * _runSpeed * Time.deltaTime);
            _isRun = true;
        }
    }

    public void Jump()
    {
        if (_groundChecker.IsGround && _isJump == false)
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _isJump = true;
            _isRun = false;
            _isFall = false;
            _fallingCoroutine = StartCoroutine(Falling());
        }
    }

    private IEnumerator Falling()
    {
        while (_rigidbody.velocity.y >= 0)
        {
            yield return null;
        }

        while (_rigidbody.velocity.y < 0)
        {
            _isFall = true;
            _isJump = false;

            yield return null;
        }

        if (_groundChecker.IsGround)
        {
            _isRun = true;
            _isFall = false;
            _isJump = false;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
        }
    }
}