using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Project.Features.Person
{
    public class PersonController : MonoBehaviour
    {
        [SerializeField] protected List<Person> people = new List<Person>();
        private int _currentPerson = 0;

        [SerializeField] protected int countEvil = 1;

        public List<Person> People => people;
        public int CurrentPerson
        {
            get
            {
                return _currentPerson;
            }
            set
            {
                if (value >= people.Count)
                {
                    _currentPerson = 0;
                    OnComplete?.Invoke();
                    return;
                }
                _currentPerson = value;
                OnPersonChange?.Invoke();
            }

        }

        public event Action OnGenerateComplete;
        public event Action OnComplete;
        public event Action OnPersonChange;

        public void GenerateGame()
        {
            people = people.OrderBy(_ => UnityEngine.Random.value).ToList();

            for (int i = 0; i < countEvil; i++)
            {
                people[i].GeneratePerson(false);
            }

            for (int i = countEvil; i < people.Count; i++)
            {
                people[i].GeneratePerson(true);
            }

            people = people.OrderBy(_ => UnityEngine.Random.value).ToList();
            OnGenerateComplete?.Invoke();
        }

        public PersonEvent GetHero(int phase)
        {
            return people[_currentPerson].GetEvent(phase);
        }
    }
}