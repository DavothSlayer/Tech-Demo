using UnityEngine;

[CreateAssetMenu(fileName = "New Player Attack Data", menuName = "Player Attack Data")]
public class PlayerAttackData : ScriptableObject
{
    [SerializeField] private float _normalAttackSpeed;
    [SerializeField] private float _heavyAttackSpeed;

    public float NormalAttackSpeed => _normalAttackSpeed;
    public float HeavyAttackSpeed => _heavyAttackSpeed;
}
