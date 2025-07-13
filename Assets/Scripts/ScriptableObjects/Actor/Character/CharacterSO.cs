using UnityEngine;

namespace ActorSO
{
    [CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/Actor/CharacterSO")]
    public class CharacterSO : ActorSO
    {
        [SerializeField] private string Name;
        public string GetName() => Name;
        [SerializeField] private float BaseSpeed;
        public float GetBaseSpeed() => BaseSpeed;
    }
}