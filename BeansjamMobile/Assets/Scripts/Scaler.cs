using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour, IEnemyBehaviour {

    public AnimationCurve scaleCurve;
    public bool startScaling = true;

    private bool isScaling = false;
    private Vector3 startScale;
    private float timer = 0;

    private void Start()
    {
        startScale = transform.localScale;

        if (startScaling)
            StartCoroutine(ScaleCoroutine());
    }

    IEnumerator ScaleCoroutine()
    {
        isScaling = true;
        while (this.enabled)
        {
            timer += Time.deltaTime;
            transform.localScale = startScale * scaleCurve.Evaluate(timer);

            yield return 0;
        }
    }

    public void Execute()
    {
        StartCoroutine(ScaleCoroutine());
    }
}
