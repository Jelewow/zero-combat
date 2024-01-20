using UnityEngine;
using ZeroCombat.AssetProvider;
using ZeroCombat.Constants;

namespace ZeroCombat.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }
        
        public GameObject CreatePlayer(GameObject at)
        {
            return _assets.Instantiate(Constant.Resources.Player, at.transform.position);
        }

        public GameObject CreateHud()
        {
            return _assets.Instantiate(Constant.Resources.Hud);
        }
    }
}