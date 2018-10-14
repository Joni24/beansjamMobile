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
    [SerializeField] private Animator animator;
    public Monster ghost;
    public Monster monster;

    public bool Execute()
    {
        if (!scaler.IsExecutable())
            return false;

        jamCollider.enabled = true;
        spriteRenderer.enabled = true;
        switch (monsterType.GetRandomMonster())
        {
            case MonsterAttraction.GHOST:
                {
                    animator.SetTrigger(AnimationHashs.GEISTERBAHN_GHOSTS);
                    scaler.scaleCurve = ghost.curve;
                    scaler.Execute();
                    audioSource.PlayOneShot(ghost.sound);
                }
                break;
            case MonsterAttraction.MONSTER:
                {
                    animator.SetTrigger(AnimationHashs.GEISTERBAHN_MONSTER);
                    scaler.scaleCurve = monster.curve;
                    scaler.Execute();
                    audioSource.PlayOneShot(monster.sound);
                }
                break;
        }
        return true;
    }


}
