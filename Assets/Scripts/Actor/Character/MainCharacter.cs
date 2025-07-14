using ActorSO;
using Managers;
using UnityEngine;

namespace Actor
{
    public abstract class MainCharacter : Actor, IControllable
    {
        [SerializeField] protected CharacterSO CharacterSO;
        [SerializeField] protected Rigidbody2D Rigidbody2D;
        [SerializeField] protected Animator Animator;
        [SerializeField] protected SpriteRenderer SpriteRenderer;

        [SerializeField] protected CharacterState CurrentState;
        public void SwitchState(CharacterState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        [SerializeField] protected float _currentSpeed;
        public float GetCurrentSpeed() => _currentSpeed;
        public virtual void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnEnable()
        {
            SetParams();
            SwitchState(new IdleState(this));
        }
        private void OnDisable()
        {

        }
        public virtual void Move(Vector2 movement)
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + GetCurrentSpeed() * Time.fixedDeltaTime * movement);
            if (movement.x < 0)
                SpriteRenderer.flipX = true;
            else
                SpriteRenderer.flipX = false;
        }
        public virtual void SetParams()
        {
            _currentSpeed = CharacterSO.GetBaseSpeed();// + ApplyModifier(ModifierType.SPEED);
        }
        #region Animations
        public virtual void SetWalking(bool isWalking)
        {
            Animator.SetBool("isWalking", isWalking);
        }
        #endregion
        #region Interfaces
        public void FeedDirection(Vector2 direction)
        {
            CurrentState?.HandleInput(direction);
        }
        #endregion
    }
}