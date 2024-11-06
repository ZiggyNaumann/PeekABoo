using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Characters
{
    public abstract class CharacterComponent : CardboardCoreBehaviour
    {
        protected override InjectTiming MyInjectTiming => InjectTiming.Start;

        public Character Owner { get; private set; }

        protected override void OnInjected()
        {

        }

        protected override void OnReleased()
        {

        }

        public void Initialize(Character owner)
        {
            Owner = owner;
        }
    }
}
