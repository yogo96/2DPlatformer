using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 MoveDirection { get; private set; }
    public bool TryJump { get; private set; }

    private const string DirectionAxis = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;

    private void Update()
    {
        float axisHorizontal = Input.GetAxis(DirectionAxis);

        if (axisHorizontal > 0)
        {
          MoveDirection = Vector3.right;
        }
        else if (axisHorizontal < 0)
        {
            MoveDirection = Vector3.left;
        }
        else
        {
            MoveDirection = Vector3.zero;
        }
        
        if (Input.GetKeyDown(JumpButton))
        {
            TryJump = true;
        }
        else if (Input.GetKeyUp(JumpButton))
        {
            TryJump = false;
        }
    }
}
