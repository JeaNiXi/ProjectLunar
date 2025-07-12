using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class ActorManager : MonoBehaviour
    {
        public static ActorManager Instance { get; private set; }

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
    }
}