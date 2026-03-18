using System.Collections.Generic;

public interface IAnimation
{
    public float Speed
    {
        get;
    }

    void Subscribe();
    void Unsubscribe();

    void ChangeSpeed(float speed);
}

public class AnimationController
{
    public List<IAnimation> AnimationList = new();

    public AnimationController()
    {
       AnimationList=new List<IAnimation>();
    }

    public void AddAnimation(IAnimation animation)
    {
        if (AnimationList.Contains(animation))
        {
            return;
        }
        AnimationList.Add(animation);
    }

    public void RemoveAnimation(IAnimation animation)
    {
        if (!AnimationList.Contains(animation))
        {
            return;
        }
        AnimationList.Remove(animation);
    }

    public void ChangeSpeed(float speed)
    {
        foreach (var animation in AnimationList)
        {
            animation.ChangeSpeed(speed);
        }
    }
}
