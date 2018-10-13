using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {

    public Pantomime pantomime;

    private float height;

    private void Start()
    {
        height = this.transform.position.y;
    }

    private void Update()
    {
        Vector3 newPos = pantomime.transform.position;
        newPos.y = height;
        this.transform.position = newPos;
    }
}
