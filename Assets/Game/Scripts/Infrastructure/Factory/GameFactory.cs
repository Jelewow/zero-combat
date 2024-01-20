using System.Collections.Generic;
using UnityEngine;
using ZeroCombat.AssetProvider;
using ZeroCombat.Constants;
using ZeroCombat.Player;

namespace ZeroCombat.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new ();
        public List<ISavedProgress> ProgressWriters { get; } = new ();

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }
        
        public GameObject CreatePlayer(GameObject at)
        {
            return InstantiateRegistered(Constant.Resources.Player, at.transform.position);
        }
        
        public GameObject CreateHud()
        {
            return InstantiateRegistered(Constant.Resources.Hud);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
        
        private GameObject InstantiateRegistered(string prefabPath, Vector3 position)
        {
            var player = _assets.Instantiate(prefabPath, position);
            RegisterProgressWatchers(player);
            return player;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            var player = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(player);
            return player;
        }
        
        private void RegisterProgressWatchers(GameObject player)
        {
            foreach (var progressReader in player.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }
        
        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter );
            }
            
            ProgressReaders.Add(progressReader);
        } 
    }
}