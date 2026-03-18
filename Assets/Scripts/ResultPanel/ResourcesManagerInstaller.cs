using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class ResourcesManagerInstaller : ScriptableObjectInstaller
    {
        [SerializeField] protected ResSystemPhase resSystemPhase;
        [SerializeField] protected PlayerStat playerStat;

        public override void InstallBindings()
        {
            Container.Bind<ResSystemPhase>().FromScriptableObject(resSystemPhase).AsSingle();
            Container.Bind<PlayerStat>().FromScriptableObject(playerStat).AsSingle();
        }
    }
}