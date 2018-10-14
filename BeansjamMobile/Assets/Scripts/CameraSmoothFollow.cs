using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {

    private Pantomime pantomime;

    private float fixedX;
    private float fixedY;
    private Vector3 startPosition;

    private void Start()
    {
        pantomime = FindObjectOfType<Pantomime>();
        startPosition = transform.position;
        fixedX = this.transform.position.x;
        fixedY = this.transform.position.y;
    }

    private void Update()
    {
        Vector3 newPos = pantomime.transform.position;
        newPos.y = fixedY;
        newPos.x = fixedX;
        this.transform.position = newPos;
    }

    public void Reset()
    {
        this.transform.position = startPosition;
    }
}
