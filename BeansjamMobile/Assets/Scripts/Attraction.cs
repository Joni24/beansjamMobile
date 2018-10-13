using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour, IAttraction {

    void Start () {
	}

    public void Execute()
    {
        print("Execute Attraction "+ name);
    }
}
