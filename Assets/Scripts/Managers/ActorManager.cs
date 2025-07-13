using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class ActorManager : MonoBehaviour
    {
        public static ActorManager Instance { get; private set; }

        private readonly List<IControllable> controllables = new List<IControllable>();
        private readonly int _currentIndex;
        public IControllable CurrentControlledCharacter => controllables.Count == 0 ? null : controllables[_currentIndex];

        

        private void Awake()
        {
            if (Instance != null && Instance != this) 
                Destroy(this);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void RegisterIControllable(IControllable c) => controllables.Add(c);
        public void UnregisterIControllable(IControllable c) => controllables.Remove(c);
        public void NextControllable() // To DO
        {
            
        }
    }
}