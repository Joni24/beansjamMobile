using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {

    public AnimationCurve scaleCurve;
    public bool startScaling = true;

    private bool isScaling = false;
    private Vector3 startScale;
    private float timer = 0;
    private float boost = 1;

    private void Start()
    {
        startScale = transform.localScale;

        if (startScaling)
            StartCoroutine(ScaleCoroutine());
    }

    IEnumerator ScaleCoroutine()
    {
        isScaling = true;
        while (timer <= scaleCurve.keys[scaleCurve.length - 1].time || scaleCurve.postWrapMode == WrapMode.Loop)
        {
            timer += Time.deltaTime;
            transform.localScale = startScale * scaleCurve.Evaluate(timer) * boost;

            yield return 0;
        }
        isScaling = false;
    }

    public void Restart()
    {
        timer = 0;
    }

    public void Execute(float boost = 1f)
    {
        this.boost = boost;
        StopAllCoroutines();
        timer = 0;
        StartCoroutine(ScaleCoroutine());
    }

    public bool IsExecutable()
    {
        return timer == 0 || !isScaling;
    }
}
