using Actor;
using UnityEngine;

namespace Actor
{
    public class WalkingState : CharacterState
    {
        public WalkingState(MainCharacter character) : base(character) { }

        public override void Enter()
        {
            character.SetWalking(true);
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void HandleInput(Vector2 movement)
        {
            if (movement == Vector2.zero)
                character.SwitchState(new IdleState(character));
            else
                character.Move(movement);
        }
    }
}