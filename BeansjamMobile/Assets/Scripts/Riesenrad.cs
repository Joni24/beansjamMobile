﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riesenrad : MonoBehaviour, IAttraction {

    [SerializeField] private Scaler scaler;
    [SerializeField] private SphereCollider jamCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;

    public bool Execute()
    {
        if (!scaler.IsExecutable())
            return false;

        animator.SetTrigger(AnimationHashs.RIESENRAD_SPIN);
        audioSource.Play();
        jamCollider.enabled = true;
        spriteRenderer.enabled = true;
        scaler.Execute();
        return true;
    }
}
