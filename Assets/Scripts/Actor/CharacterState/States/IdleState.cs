using Actor;
using UnityEngine;

namespace Actor
{
    public class IdleState : CharacterState
    {
        public IdleState (MainCharacter character) : base (character) { }

        public override void Enter()
        {
            character.SetWalking(false);
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void HandleInput(Vector2 movement)
        {
            if (movement != Vector2.zero)
            {
                character.SwitchState(new WalkingState(character));
            }
        }
    }
}