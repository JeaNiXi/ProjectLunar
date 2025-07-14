using Actor;
using UnityEngine;

namespace Actor
{
    public abstract class CharacterState
    {
        protected MainCharacter character;
        public CharacterState(MainCharacter character) => this.character = character;
        
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void HandleInput(Vector2 movement) { }

    }
}