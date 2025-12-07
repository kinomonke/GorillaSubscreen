using BepInEx;
using GorillaSubscreen.Tools;
using System.Threading.Tasks;
using UnityEngine;

namespace GorillaSubscreen
{

    [BepInPlugin(Constants.GUID, Constants.NAME, Constants.VERS)]
    public class Plugin : BaseUnityPlugin
    {
        GameObject _GSPrefab;
        void Awake() => GorillaTagger.OnPlayerSpawned(async() => await SetupBoard());

        async Task SetupBoard()
        {
            try
            {
                _GSPrefab = await AssetLoader.LoadAsset<GameObject>("GorillaSubBoard");
                if (_GSPrefab == null)
                {
                    Debug.LogError("[GS]: Failed to load AssetBundle.");
                    return;
                }
                
                var gsInstance = Instantiate(_GSPrefab);
                gsInstance.SetActive(true);
                gsInstance.transform.position = new Vector3(-62.8232f, 12.6908f, -83.8681f);
                gsInstance.transform.rotation = Quaternion.Euler(0.886f, 95.4097f, 0f);
            }
            catch { Debug.LogError("[GS]: Error setting up board."); }
        }
    }
    public class Constants
    {
        public const string GUID = "kino.gorillasubscreen",
                            NAME = "GorillaSubscreen",
                            VERS = "1.0.0";
    }
}