using UnityEngine;

namespace ZeroCombat.Services.Input
{
    public class MobileInputService: InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}