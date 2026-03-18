using System;
using System.Collections.Generic;

using UnityEngine;

namespace Project.Features.Person
{
    [Serializable]
    public class Person
    {
        [SerializeField] private PersonData data;
        private List<PersonEvent> _personEvents = new List<PersonEvent>();

        public PersonData Data { get => data; private set => data = value; }

        public bool isGood = false;

        public void GeneratePerson(bool isGood)
        {
            _personEvents = data.GetEvent(3, isGood);
        }

        public PersonEvent GetEvent(int id)
        {
            return _personEvents[id];
        }
    }
}