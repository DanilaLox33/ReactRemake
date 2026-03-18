using System.Collections.Generic;
using UnityEngine;

namespace Project.Features.DialogSystem
{
    [CreateAssetMenu(fileName = "DialogCharacter",menuName = "DialogSystem/DialogCharacter")]
    public class DialogCharacter : ScriptableObject
    {
        [Header("Main setting")]
        public Sprite Icon;
        public string Name;

        [Header("React setting")]
        public Sprite OriginSprite;
        public List<Sprite> ReactSprities;

        [Header("Sound setting")]
        public AudioClip PersonAudio;
    }
}