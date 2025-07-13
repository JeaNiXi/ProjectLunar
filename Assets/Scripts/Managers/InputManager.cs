using Actor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {

        private LunarInput _lunarInput;
        private InputAction _movement;
        private void Awake()
        {
            _lunarInput = new LunarInput();
        }
        private void OnEnable()
        {
            _movement = _lunarInput.Character.Movement;
            _movement.Enable();
        }
        private void OnDisable()
        {
            _movement.Disable();
        }
        private void FixedUpdate()
        {
            IControllable currentCharacter = ActorManager.Instance.CurrentControlledCharacter;
            if (currentCharacter == null)
                return;
            var dir = _movement.ReadValue<Vector2>();
            dir = dir.sqrMagnitude < 0.001f ? Vector2.zero : dir.normalized;
            currentCharacter.FeedDirection(dir);
        }
    }
}