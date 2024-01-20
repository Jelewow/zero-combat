using UnityEngine;
using ZeroCombat.Infrastructure.Services;

namespace ZeroCombat.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);

        GameObject Instantiate(string path, Vector3 at);
    }
}