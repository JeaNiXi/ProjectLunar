using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        
        public AudioSource audioSource;

        public AudioClip switchSound;
        public AudioClip mainTheme;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(Instance);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        private void Start()
        {
            audioSource.PlayOneShot(mainTheme);
        }
        public void PlaySwitchSound()
        {
            audioSource.PlayOneShot(switchSound);

        }
    }
}