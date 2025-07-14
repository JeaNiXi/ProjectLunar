using Actor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {

        private LunarInput _lunarInput;
        private InputAction _movement;
        private InputAction _characterSwitch;
        private void Awake()
        {
            _lunarInput = new LunarInput();
        }
        private void OnEnable()
        {
            _movement = _lunarInput.Character.Movement;
            _characterSwitch = _lunarInput.Character.SwitchCharacter;
            _movement.Enable();
            _characterSwitch.performed += SwitchCharacter;
            _characterSwitch.Enable();
        }
        private void OnDisable()
        {
            _movement.Disable();
            _characterSwitch.Disable();
        }
        private void Update()
        {
            
        }
        private void FixedUpdate()
        {
            MainCharacter currentCharacter = ActorManager.Instance.GetCurrentActiveCharacter();
            if (currentCharacter == null)
                return;
            var dir = _movement.ReadValue<Vector2>();
            dir = dir.sqrMagnitude < 0.001f ? Vector2.zero : dir.normalized;
            currentCharacter.FeedDirection(dir);
        }
        private void SwitchCharacter(InputAction.CallbackContext obj)
        {
            KeyControl key = obj.control as KeyControl;
            switch (key.keyCode)
            {
                case Key.Digit1:
                    ActorManager.Instance.SetNewCharacter(0);
                    break;
                case Key.Digit2:
                    ActorManager.Instance.SetNewCharacter(1);
                    break;
            }
        }
    }
}