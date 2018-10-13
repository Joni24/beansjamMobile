using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {

    public float minScale = 1f;
    public float maxScale = 3f;
    public float speed = 1f;
    public float delayTime = 1f;

    private int direction = 1;
    private Vector3 minScaleVector;
    private Vector3 maxScaleVector;
    private Vector3 startScale;
    private WaitForSeconds waitTime; 

    private void Start()
    {
        waitTime = new WaitForSeconds(delayTime);
        startScale = transform.localScale;
        minScaleVector = new Vector3(minScale, minScale, minScale);
        maxScaleVector = new Vector3(maxScale, maxScale, maxScale);
        StartCoroutine(ScaleCoroutine());
    }

    IEnumerator ScaleCoroutine()
    {
        float value = minScale;
        while(this.enabled)
        {
            value += Time.deltaTime * speed * direction;
            if (value > maxScale)
            {
                value = maxScale;
                direction *= -1;
                yield return waitTime;
            }
            else if (value < minScale)
            {
                value = minScale;
                direction *= -1;
                yield return waitTime;
            }

            transform.localScale = startScale * value;
            yield return 0;
        }
    }
}
