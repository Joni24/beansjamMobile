using UnityEngine;
using System;

public enum MonsterAttraction { GHOST = 1, MONSTER = 2 }

[Serializable]
public class Monster
{
    public AnimationCurve curve;
    public AudioClip sound;
}

public class Geisterbahn : MonoBehaviour, IAttraction {

    private MonsterAttraction monsterType;
    [SerializeField] private Scaler scaler;
    [SerializeField] private SphereCollider jamCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;
    public Monster ghost;
    public Monster monster;

    public void Execute()
    {
        if (!scaler.IsExecutable())
            return;

        jamCollider.enabled = true;
        spriteRenderer.enabled = true;
        switch (monsterType.GetRandomMonster())
        {
            case MonsterAttraction.GHOST:
                {
                    scaler.scaleCurve = ghost.curve;
                    scaler.Execute(1);
                    audioSource.PlayOneShot(ghost.sound);
                }
                break;
            case MonsterAttraction.MONSTER:
                {
                    scaler.scaleCurve = monster.curve;
                    scaler.Execute(1);
                    audioSource.PlayOneShot(monster.sound);
                }
                break;
        }

    }


}
