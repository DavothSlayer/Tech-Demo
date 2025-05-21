using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerLocomotionData _playerLocomotionData;

    private IInputStrategy _inputStrategy;

    private void Awake()
    {
        _inputStrategy = new InputWASD();
    }

    private void Update()
    {
        
    }

    private void HandleMovement()
    {        

    }
}
