using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class LineNewController : MonoBehaviour,IAnimation
{
    [SerializeField] protected LineNew line;
    [SerializeField] protected float showTime=20f;
    [SerializeField] protected List<string> _randomNews= new();

    private float _speed = 1f;

    protected Coroutine _moveCorrutine;
    [Inject] private AnimationController _animationController;

    public float Speed => _speed;
    
    private void Awake()
    {
        _moveCorrutine=StartCoroutine(MoveLine());
    }

    public IEnumerator MoveLine()
    {
        line.SetText(_randomNews[Random.Range(0, _randomNews.Count - 1)]);
        yield return new WaitForSeconds(0.2f/_speed);
        var target = new Vector3(line.LengthLine, 0, 0);
        line.transform.localPosition = target;
        var move = line.transform.DOLocalMove(-target * 1.25f, showTime/_speed);
        yield return move.WaitForCompletion();
        yield return MoveLine();
    }

    private void OnDestroy()
    {
        StopCoroutine(MoveLine());
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
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
        Debug.Log("I change speed");
        _speed = speed;
    }
}
