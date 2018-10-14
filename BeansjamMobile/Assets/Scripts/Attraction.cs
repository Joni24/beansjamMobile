using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour, IAttraction {

    void Start () {
	}

    public bool Execute()
    {
        print("Execute Attraction "+ name);
        return true;
    }
}
