using UnityEngine;

public class MovePlayer : MonoBehaviour {

    private Pantomime pantomime;

    public float forwardSpeed = 2f;
    public float lateralSpeed = 3f;
    public float movementBounds = 2f;

    public void Initialize(Pantomime p)
    {
        this.pantomime = p;
    }

    void Update () {
        this.transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
    }

    public void MoveRight()
    {
        Vector3 newPos = this.transform.position + Vector3.right * Time.deltaTime * lateralSpeed;

        if(newPos.x < movementBounds)
            this.transform.position = newPos;
    }

    public void MoveLeft()
    {
        Vector3 newPos = this.transform.position - Vector3.right * Time.deltaTime * lateralSpeed;

        if (newPos.x > -movementBounds)
            this.transform.position = newPos;
    }
}
