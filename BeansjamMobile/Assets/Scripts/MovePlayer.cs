using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float forwardSpeed = 2f;
    public float lateralSpeed = 3f;
    public float movementBounds = 2f;

	void Update () {
        this.transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;

        if(Input.touchSupported)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2.0f)
            {
                MoveLeft();
            }
            else if (touch.position.x >= Screen.width / 2.0f)
            {
                MoveRight();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
        }


    }

    private void MoveRight()
    {
        Vector3 newPos = this.transform.position + Vector3.right * Time.deltaTime * lateralSpeed;

        if(newPos.x < movementBounds)
            this.transform.position = newPos;
    }

    private void MoveLeft()
    {
        Vector3 newPos = this.transform.position - Vector3.right * Time.deltaTime * lateralSpeed;

        if (newPos.x > -movementBounds)
            this.transform.position = newPos;
    }
}
