using ZeroCombat.Constants;
using UnityEngine;

namespace ZeroCombat.Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp() => SimpleInput.GetButtonUp(Constant.Input.Fire);
        
        protected static Vector2 SimpleInputAxis() => new(SimpleInput.GetAxis(Constant.Input.Horizontal), SimpleInput.GetAxis(Constant.Input.Vertical));

        protected static Vector2 UnityAxis() => new(UnityEngine.Input.GetAxis(Constant.Input.Horizontal), UnityEngine.Input.GetAxis(Constant.Input.Vertical));
    }
}