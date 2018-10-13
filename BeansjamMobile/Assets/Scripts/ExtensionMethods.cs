using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
    public static MonsterAttraction GetRandomMonster(this MonsterAttraction monster)
    {
        int r = Random.Range(1, 3);
        return (MonsterAttraction)r;
    }
}