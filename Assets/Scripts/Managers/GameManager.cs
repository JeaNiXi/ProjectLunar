using Actor;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [field: SerializeField] public MainCharacter CurrentCharacter { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(Instance);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            //Application.targetFrameRate = 60;
        }
    }
}