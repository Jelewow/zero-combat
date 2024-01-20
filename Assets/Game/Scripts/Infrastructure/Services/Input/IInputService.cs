using UnityEngine;
using ZeroCombat.Infrastructure.Services;

namespace ZeroCombat.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}