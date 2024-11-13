using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string DirectionAxis = "Horizontal"; 
    private const KeyCode JumpButton = KeyCode.Space;
    
    public Vector3 MoveDirection { get; private set; }
    public bool Jump { get; private set; }

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
            Jump = true;
        }
        else if (Input.GetKeyUp(JumpButton))
        {
            Jump = false;
        }
    }
}