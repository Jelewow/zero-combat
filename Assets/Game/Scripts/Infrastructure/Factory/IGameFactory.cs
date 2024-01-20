using System.Collections.Generic;
using UnityEngine;
using ZeroCombat.Infrastructure.Services;
using ZeroCombat.Player;

namespace ZeroCombat.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);

        GameObject CreateHud();
        void Cleanup();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
    }
}