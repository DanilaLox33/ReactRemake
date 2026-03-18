using UnityEngine;

namespace Project.Features.DialogSystem
{
    [CreateAssetMenu(fileName = "ResSystemPhase")]
    public class ResSystemPhase : ScriptableObject
    {
        public int Power;

        public void AddStat(int stat)
        {
            Power += stat;
        }

        public void Reset()
        {
            Power = 0;
        }
    }
}