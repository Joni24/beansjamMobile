using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riesenrad : MonoBehaviour, IAttraction {

    [SerializeField] private Scaler scaler;
    [SerializeField] private SphereCollider jamCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;

    public void Execute()
    {
        if (!scaler.IsExecutable())
            return;

        jamCollider.enabled = true;
        spriteRenderer.enabled = true;
        scaler.Execute();
    }
}
