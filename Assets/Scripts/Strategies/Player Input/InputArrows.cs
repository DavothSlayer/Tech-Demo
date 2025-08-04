using UnityEngine;

public class InputArrows : IInputStrategy
{
    public Vector2 MovementInput()
    {
        return new Vector2(
            Input.GetKey(KeyCode.RightArrow) ? 1 : Input.GetKey(KeyCode.LeftArrow) ? -1 : 0,
            Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0
            );
    }
}
