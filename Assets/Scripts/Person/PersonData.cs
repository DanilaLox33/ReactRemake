using System.Collections.Generic;
using System.Linq;
using Project.Features.DialogSystem;
using UnityEngine;

namespace Project.Features.Person
{

    [CreateAssetMenu(fileName = "PersonData", menuName = "Characters/PersonData")]
    public class PersonData : ScriptableObject
    {
        [SerializeField] protected DialogCharacter characterData;
        public List<PersonEvent> personEvents = new List<PersonEvent>();

        public DialogCharacter CharacterData => characterData;

        public List<PersonEvent> GetEvent(int count,bool isGood)
        {
            var events= personEvents.OrderBy(_ => Random.value).Take(count).ToList();
            foreach (var eve in events)
            {
                eve.isGood = isGood;
            }
            return events;
        }
    }
}