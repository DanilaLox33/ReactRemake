using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using Project.Features.Person;

public class PersonQueueView : MonoBehaviour
{
    [SerializeField] private PersonController _personController;

    [SerializeField] private GameObject personPanelPrefab;
    [SerializeField] private RectTransform loupe;
    [SerializeField] private Color hideColor = Color.black;

    private readonly Color _viewColor = Color.white;
    private readonly Dictionary<Person, (RectTransform, Image)> _panels = new();
    private HorizontalLayoutGroup _horizontalLayoutGroup;
    private Person _currentPerson;

    private readonly float _animationDuration = 0.6f;

    public void Init()
    {
        _horizontalLayoutGroup = transform.GetComponent<HorizontalLayoutGroup>();

        SubscribeToControllerEvents();
        
        CreatePersonPanels(_personController.People);
        UpdateLayoutGroup();
        
        _currentPerson = GetCurrentPerson();
        ChangePersonView();
    }

    private void OnEnable()
    {
        _personController.OnGenerateComplete += Init;
    }

    private void OnDisable()
    {
        _personController.OnGenerateComplete -= Init;
    }

    private void SubscribeToControllerEvents()
    {
        _personController.OnPersonChange += ChangePersonView;
        _personController.OnComplete += ChangePersonView;
    }

    private void CreatePersonPanels(List<Person> persons)
    {
        foreach (var person in persons)
        {
            GameObject panel = InstantiatePersonPanel(person);

            var panelRect = panel.GetComponent<RectTransform>();
            var personIcon = panel.transform.GetChild(1).GetComponent<Image>();
            
            _panels.Add(person, (panelRect, personIcon));
            FillPanelSpriteAndColor(panel, person);
        }
    }

    private GameObject InstantiatePersonPanel(Person person)
    {
        GameObject panel = Instantiate(personPanelPrefab, transform);
        panel.name = person.Data.CharacterData.Name;
        return panel;
    }

    private void FillPanelSpriteAndColor(GameObject panel, Person person)
    {
        Image personIcon = _panels[person].Item2;
        personIcon.sprite = person.Data.CharacterData.OriginSprite;
        personIcon.color = hideColor;
    }

    private void UpdateLayoutGroup()
    {
        _horizontalLayoutGroup.CalculateLayoutInputHorizontal();
        _horizontalLayoutGroup.SetLayoutHorizontal();
    }

    private Person GetCurrentPerson() => 
        _personController.People[_personController.CurrentPerson];

    private void ChangePersonView()
    {
        SetHideColorForCurrentPerson();
        _currentPerson = GetCurrentPerson();
        
        SetLoupePosition(_currentPerson);
        SetViewColorFor(_currentPerson);
    }

    private void SetHideColorForCurrentPerson()
    {
        Image personIcon = _panels[_currentPerson].Item2;
        personIcon.DOColor(hideColor, _animationDuration).SetEase(Ease.Flash);
    }

    private void SetLoupePosition(Person person)
    {
        loupe.SetAsLastSibling();

        RectTransform personPanel = _panels[person].Item1;
        
        Vector2 targetPosition = new(personPanel.localPosition.x, loupe.localPosition.y);
        loupe.DOLocalMove(targetPosition, _animationDuration).SetEase(Ease.OutBounce);
    }

    private void SetViewColorFor(Person person)
    {
        Image personIcon = _panels[person].Item2;
        personIcon.DOColor(_viewColor, _animationDuration).SetEase(Ease.Flash);
    }
}
