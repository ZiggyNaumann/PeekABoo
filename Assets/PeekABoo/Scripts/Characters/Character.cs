using CardboardCore.DI;

namespace PeekABoo.Characters
{
    public abstract class Character : CardboardCoreBehaviour
    {
        private CharacterComponent[] characterComponents;

        protected override void OnInjected()
        {
            characterComponents = GetComponents<CharacterComponent>();

            foreach (CharacterComponent characterComponent in characterComponents)
            {
                characterComponent.Initialize(this);
            }
        }

        protected override void OnReleased()
        {

        }

        public T GetCharacterComponent<T>() where T : CharacterComponent
        {
            foreach (CharacterComponent characterComponent in characterComponents)
            {
                if (characterComponent is T component)
                {
                    return component;
                }
            }

            return null;
        }
    }
}
