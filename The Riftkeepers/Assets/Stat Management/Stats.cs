using UnityEngine;
using System.Collections.Generic;
using System.Linq;



[System.Serializable]
public class Stat
{
    public int value;
    public int maxValue = -1;

    private readonly List<Modifier> activeModifiers;

    public Stat() : this(0) 
    {
    
    }
   

    public Stat (int input)
    {
        value = input;
    }

    public Stat (int input1, int input2)
    {
        value = input1;
        maxValue = input2;
    }



    public void addModifier(Modifier mod)
    {
        activeModifiers.Add(mod);
    }

    public void dropModifier(Modifier mod)
    {
        activeModifiers.Remove(mod);
    }

    public int getModifiedStat()
    {
        int modStat = value + activeModifiers.Sum(mod => mod.effect);
        if(modStat > maxValue)
        {
            if (maxValue == -1) 
            {
                return modStat;
            }

            else
            {
                return maxValue;
            }
        }

        else
        {
            return modStat;
        }
    }

}

[System.Serializable]
public class Modifier
{
    public readonly int effect;

    public Modifier( int input)
    {
        effect = input;
    }
}


