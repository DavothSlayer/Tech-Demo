using UnityEngine;

public class InputWASD : IInputStrategy
{
    public Vector2 MovementInput()
    {
        return new Vector2(
            Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0,
            Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0
            );
    }
}
