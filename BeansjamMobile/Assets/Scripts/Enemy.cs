using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public IEnemyBehaviour behaviour;

	void Update () {
        behaviour.Execute();
	}
}
