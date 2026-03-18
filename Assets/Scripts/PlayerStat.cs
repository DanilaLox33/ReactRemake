using System;
using UnityEngine;

[Serializable]
public class CountryStat
{
    [SerializeField] protected int[] res = new int[3];

    public Action<CountryStat> onStateChange;

    public int[] Res { get => res; protected set => res = value; }

    public static CountryStat operator +(CountryStat counter1, CountryStat counter2)
    {
        for (int i = 0; i < 3; i++)
        {
            counter1.res[i] += counter2.res[i];
        }
        counter1.onStateChange?.Invoke(counter1);
        return counter1;
    }

    public void Reset()
    {
        for (int i = 0; i < 3; i++)
        {
            res[i] = 0;
        }
    }
}

[CreateAssetMenu(fileName = "PlayerStat")]
public class PlayerStat : ScriptableObject
{
    [SerializeField] private int _power=5;
    [SerializeField] private int _money = 4;

    public event Action<int> OnMoneyChange;
    public event Action<int> OnPowerChange;

    public void ResetStat()
    {
        _money = 4;
    }


    public int Power
    { 
        get => _power;
        set
        {
            _power = value;
            OnPowerChange?.Invoke(_power);
        }
    }

    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            OnMoneyChange?.Invoke(value);
        }
    }
}
