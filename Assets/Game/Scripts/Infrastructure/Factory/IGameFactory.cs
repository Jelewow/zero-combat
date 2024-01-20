using UnityEngine;
using ZeroCombat.Infrastructure.Services;

namespace ZeroCombat.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);

        GameObject CreateHud();
    }
}