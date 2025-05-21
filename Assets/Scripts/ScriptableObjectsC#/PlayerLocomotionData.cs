using UnityEngine;

[CreateAssetMenu(fileName = "New Player Locomotion Data", menuName = "Player Locomotion Data")]
public class PlayerLocomotionData : ScriptableObject
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;

    public float WalkSpeed => _walkSpeed;
    public float SprintSpeed => _sprintSpeed;
}
