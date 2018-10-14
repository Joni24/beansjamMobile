using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {

    public Pantomime pantomime;

    private float fixedX;
    private float fixedY;

    private void Start()
    {
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
}
