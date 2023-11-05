using Assets.Visitor;
using UnityEngine;

public class EnemyWeight : IEnemyVisitor
{
    private int _value = 0;
    private int _limit = 200;
    private int _orkWeight = 20;
    private int _humanWeight = 5;
    private int _elfWeight = 30;
    private int _robotWeight = 15;

    public int Value { get => _value; private set => _value = value; }

    public bool IsWeightLimited { get; private set; }

    public void Reset()
    {
        Value = 0;
    }

    public void Visit(Enemy enemy)
    {
        Visit((dynamic)enemy);
        CheckLimit();
        Debug.Log("Вес: " + Value);
    }

    public void Visit(Ork ork)
    {
        if (ork.IsDied)
        {
            Value -= _orkWeight;
        }
        else
        {
            Value += _orkWeight;
        }
    }

    public void Visit(Human human)
    {
        if(human.IsDied)
        {
            Value -= _humanWeight;
        }
        else
        {
            Value += _humanWeight;
        }
    }

    public void Visit(Elf elf)
    {
        if (elf.IsDied)
        {
            Value -= _elfWeight;
        }
        else
        {
            Value += _elfWeight;
        }
    }

    public void Visit(Robot robot)
    {
        if (robot.IsDied)
        {
            Value -= _robotWeight;
        }
        else
        {
            Value += _robotWeight;
        }
    }

    private void CheckLimit()
    {
        IsWeightLimited = Value >= _limit;
    }
}