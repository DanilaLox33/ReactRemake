using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class ComicsController : MonoBehaviour,IAnimation
{
    [SerializeField] protected List<Image> images = new List<Image>();
    [SerializeField] protected float timeShow = 1.5f;
    [SerializeField] protected GameObject button;

    [SerializeField] protected UnityEvent onComicaComplete;
    private float _speed=1;
    
    private AnimationController _animationController;
    
    public float Speed => _speed;

    [Inject]
    public void Construct(AnimationController animationController)
    {
        _animationController=animationController;
    }

    public virtual void OnEnable()
    {
        Subscribe();
        StartCoroutine(FillFrames());
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    public virtual IEnumerator FillFrames()
    {
        foreach (var image in images)
        {
            var move = image.DOFillAmount(1, timeShow/_speed);
            yield return move.WaitForCompletion();
        }

        button.SetActive(true);
    }

    public virtual void CompleteComics()
    {
        onComicaComplete?.Invoke();
        gameObject.SetActive(false);
    }

    public void Subscribe()
    {
        _animationController.AddAnimation(this);
    }

    public void Unsubscribe()
    {
        _animationController.RemoveAnimation(this);
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }
}
