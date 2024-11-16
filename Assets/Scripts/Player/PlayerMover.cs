using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    public bool IsJump { get; private set; }
    public bool IsFall { get; private set; }
    public bool IsRun { get; private set; }

    [SerializeField] private float _runSpeed = 0.5f;
    [SerializeField] private float _jumpForce = 9f;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private int _rotateDegrees = 180;
    private int _rotateZeroDegrees = 0;
    private Coroutine _fallingCoroutine;

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
            IsRun = false;
        }
        else
        {
            float rotateDegrees = 0;

            if (direction.Equals(Vector3.left))
            {
                rotateDegrees = _rotateDegrees;
            }

            transform.rotation = Quaternion.Euler(_rotateZeroDegrees, rotateDegrees, _rotateZeroDegrees);
            transform.Translate(Vector3.right * _runSpeed * Time.deltaTime);
            IsRun = true;
        }
    }

    public void Jump()
    {
        if (_groundChecker.IsGround && IsJump == false)
        {
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            IsJump = true;
            IsRun = false;
            IsFall = false;
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
            IsFall = true;
            IsJump = false;

            yield return null;
        }

        if (_groundChecker.IsGround)
        {
            IsRun = true;
            IsFall = false;
            IsJump = false;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
        }
    }
}