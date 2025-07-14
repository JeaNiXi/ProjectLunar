using Actor;
using System.Collections.Generic;
using UnityEngine;

namespace ManagersSO
{
    [CreateAssetMenu(fileName = "ActorManagerData", menuName = "Scriptable Objects/Managers/ActorManagerData")]
    public class ActorManagerDataSO : ScriptableObject
    {
        [SerializeField] private int CurrentCharacterIndex;
        public int GetCurrentCharacterIndex() =>
            CurrentCharacterIndex;
        public void SetCurrentCharacterIndex(int index)
        {
            CurrentCharacterIndex = index;
        }
        [SerializeField] public List<MainCharacter> CurrentCharacters = new List<MainCharacter>();

    }
}