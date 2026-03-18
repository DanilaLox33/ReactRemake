using System;
using UnityEngine;

using Project.Features.Person;

[CreateAssetMenu(fileName = "SpySystem")]
public class SpySystem : ScriptableObject
{
    [SerializeField] private PersonEvent currentPersonEvent;

    public PersonEvent CurrentPersonEvent { get => currentPersonEvent;private set => currentPersonEvent = value; }

    public event Action onTargetEvent;

    public void TargetEvent()
    {
        onTargetEvent?.Invoke();
    }

    public void SetCurrentEvent(PersonEvent personEvent)
    {
        currentPersonEvent = personEvent;
    }
}
