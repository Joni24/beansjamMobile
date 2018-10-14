using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantomime : MonoBehaviour {
    public PlayerInput playerInput;
    public MovePlayer movePlayer;

    private const float raycastDistance = 20f;
    public float radius = 1.5f;
    public bool showDebug = true;

    private List<Transform> samplePoints = new List<Transform>();
    public int samples = 8;

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        playerInput.Initialize(this);
        movePlayer.Initialize(this);
    }

    private void Start()
    {
        // spawn sample points
        Vector3 offset = new Vector3(radius, raycastDistance, 0f);
        float slice = 360f / samples;

        for (int i = 0; i < samples; i++)
        {
            var go = new GameObject("samplePoint " + (i + 1));
            samplePoints.Add(go.transform);
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position + offset;
            go.transform.RotateAround(transform.position, Vector3.up, slice * i);
        }
    }

    public void Die()
    {
        //Debug.Log("SHAME SHAME, YOU ARE NOT A PANTOMIME ANYMORE!");
        transform.position = startPosition;
    }

    private void FixedUpdate()
    {
        // raycast down from every sample point and check if none of them hits a AttentionField, Attention Field + Jam Field is cool
        bool insideJam = false;
        foreach (var sample in samplePoints)
        {
            if(showDebug) Debug.DrawRay(sample.position, Vector3.down * raycastDistance);
            RaycastHit[] hits = Physics.RaycastAll(sample.position, Vector3.down, raycastDistance);

            foreach (var hit in hits)
            {
                if (hit.collider.tag == Tags.JAMFIELD)
                    insideJam = true;
            }

            if (hits.Length > 0 && !insideJam)
                Die();
        }
    }
}
