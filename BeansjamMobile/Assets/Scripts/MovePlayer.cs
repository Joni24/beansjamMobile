using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float forwardSpeed = 2f;
    public float lateralSpeed = 3f;

	void Update () {
        this.transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= Vector3.right * Time.deltaTime * lateralSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * Time.deltaTime * lateralSpeed;
        }
    }
}
