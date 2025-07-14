using Actor;
using ManagersSO;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class ActorManager : MonoBehaviour
    {
        public static ActorManager Instance { get; private set; }
        [SerializeField] ActorManagerDataSO ActorManagerSO;

        [SerializeField] private List<MainCharacter> CurrentCharactersList = new List<MainCharacter>();
        [SerializeField] private MainCharacter CurrentMainCharacter;
        [SerializeField] private int CurrentCharacterIndex;
        public MainCharacter GetCurrentActiveCharacter() =>
            CurrentMainCharacter;
        public int GetCurrentCharacterIndex =>
            CurrentCharacterIndex;
        
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
        private void OnEnable()
        {
            CreateCharacterList();
            InstantiateCharacter();
        }
        #region CharacterControl
        public void SetNewCharacter(int index)
        {
            if (index >= CurrentCharactersList.Count)
                return;
            ChangeCharacter(index);
        }
        private void CreateCharacterList()
        {
            foreach (MainCharacter currentCharacterPrefab in ActorManagerSO.CurrentCharacters) 
                CurrentCharactersList.Add(currentCharacterPrefab);
        }
        private void InstantiateCharacter()
        {
            CurrentCharacterIndex = ActorManagerSO.GetCurrentCharacterIndex();
            Debug.Log(CurrentCharacterIndex + " " + CurrentCharactersList[CurrentCharacterIndex].name);
            CurrentMainCharacter = Instantiate(CurrentCharactersList[CurrentCharacterIndex], Vector2.zero, Quaternion.identity);
        }
        private void ChangeCharacter(int index)
        {
            Destroy(CurrentMainCharacter.gameObject);
            ActorManagerSO.SetCurrentCharacterIndex(index);
            CurrentCharacterIndex = ActorManagerSO.GetCurrentCharacterIndex();
            AudioManager.Instance.PlaySwitchSound();
            InstantiateCharacter();
        }
        public void NextControllable() // To DO
        {

        }
        #endregion;
    }
}