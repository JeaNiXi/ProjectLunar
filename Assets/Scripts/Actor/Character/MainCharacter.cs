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

        [SerializeField] protected float _currentSpeed;
        public float GetCurrentSpeed() => _currentSpeed;

        protected enum CharacterState
        {
            IDLE,
            WALKING
        }
        [SerializeField] protected CharacterState CurrentCharacterState = CharacterState.IDLE;
        protected enum AnimationState
        {
            IDLE,
            WALKING
        }
        [SerializeField] protected AnimationState CurrentAnimationState = AnimationState.IDLE;

        public virtual void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnEnable()
        {
            ActorManager.Instance.RegisterIControllable(this);
            SetParams();
        }
        private void OnDisable()
        {
            ActorManager.Instance.UnregisterIControllable(this);
        }
        public virtual void Move(Vector2 movement)
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + GetCurrentSpeed() * Time.fixedDeltaTime * movement);
            if (movement.x < 0)
                SpriteRenderer.flipX = true;
            else
                SpriteRenderer.flipX = false;
            if (CurrentCharacterState != CharacterState.WALKING)
            {
                Debug.Log("Changed to Walking State");
                CurrentCharacterState = CharacterState.WALKING;
            }
        }
        public virtual void StopMovement()
        {
            if (CurrentCharacterState != CharacterState.IDLE)
            {
                Debug.Log("Changed to IDLE State");
                CurrentCharacterState = CharacterState.IDLE;
            }
        }
        public virtual void SetParams()
        {
            _currentSpeed = CharacterSO.GetBaseSpeed();// + ApplyModifier(ModifierType.SPEED);
        }
        protected virtual void PlayAnimation(AnimationState animationState)
        {
            switch (animationState)
            {
                case AnimationState.IDLE:
                    Animator.SetBool("isWalking", false);
                    CurrentAnimationState = AnimationState.IDLE;
                    break;
                case AnimationState.WALKING:
                    Animator.SetBool("isWalking", true);
                    CurrentAnimationState = AnimationState.WALKING;
                    break;
            }
        }
        public virtual void UpdateCharacterAnimationState()
        {
            switch (CurrentCharacterState)
            {
                case CharacterState.IDLE:
                    PlayAnimation(AnimationState.IDLE);
                    break;
                case CharacterState.WALKING:
                    PlayAnimation(AnimationState.WALKING);
                    break;
            }
        }
        #region InputHandling
        public virtual void HandleMovement(Vector2 movementVector)
        {
            if(movementVector == Vector2.zero)
            {
                StopMovement();
                UpdateCharacterAnimationState();
            }
            else
            {
                Move(movementVector);
                UpdateCharacterAnimationState();
            }
        }
        #endregion
        #region Interfaces
        public void FeedDirection(Vector2 direction)
        {
            HandleMovement(direction);
        }
        #endregion
    }
}