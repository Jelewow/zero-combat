using UnityEngine;

namespace ZeroCombat.Constants
{
    public static class Constant
    {
        public const float Epsilon = 0.001f;

        public static class Tags
        {
            public const string InitialPoint = nameof(InitialPoint);
        }
        
        public static class Resources
        {
            public const string Player = "Prefabs/MainCharacter/Player";
            public const string Hud = "Prefabs/UI/Hud";
        }
        
        public static class Scenes
        {
            public const string Initial = nameof(Initial);
            public const string Main = nameof(Main);
        }
        
        public static class Input
        {
            public const string Horizontal = nameof(Horizontal);
            public const string Vertical = nameof(Vertical);
            public const string Fire = nameof(Fire);
        }

        public static class Animator
        {
            public static readonly int MoveHash = UnityEngine.Animator.StringToHash("RunRifle");
            public static readonly int MeleeAttackHash = UnityEngine.Animator.StringToHash("MeleeAttack");
            public static readonly int RifleFireHash = UnityEngine.Animator.StringToHash("RifleFire");
            public static readonly int GetHitHash = UnityEngine.Animator.StringToHash("GetHit");
            public static readonly int IdleHash = UnityEngine.Animator.StringToHash("Idle");

            public static readonly int DiedHash = UnityEngine.Animator.StringToHash("Died");

            public static class Variables
            {
                public static readonly int Speed = UnityEngine.Animator.StringToHash("Speed");
            }
        }

        public static class Prefs
        {
            public const string Progress = nameof(Progress);
        }
    }
}