using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseField : MonoBehaviour {

    private Pantomime pantomime;

    public void Initialize(Pantomime p)
    {
        pantomime = p;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log(other.name);
    //    pantomime.Die();
    //}
}
