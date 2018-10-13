using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private Pantomime pantomime;

    public void Initialize(Pantomime p)
    {
        this.pantomime = p;
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            Touch touch = Input.GetTouch(0);

            // touch hits a attraction, else move player
            TouchRaycast(touch.position);

            if (touch.position.x < Screen.width / 2.0f)
            {
                pantomime.movePlayer.MoveLeft();
            }
            else if (touch.position.x >= Screen.width / 2.0f)
            {
                pantomime.movePlayer.MoveRight();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
                TouchRaycast(Input.mousePosition);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pantomime.movePlayer.MoveLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                pantomime.movePlayer.MoveRight();
            }
        }
    }

    private void TouchRaycast(Vector3 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red);
        var hits = Physics.RaycastAll(ray);

        foreach (var item in hits)
        {
            if (item.collider.tag == Tags.JAMFIELD)
                item.collider.GetComponentInParent<IAttraction>().Execute();
        }
    }
}
