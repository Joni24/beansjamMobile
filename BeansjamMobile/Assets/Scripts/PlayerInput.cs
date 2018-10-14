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
            if(TouchRaycast(touch.position))
                return;

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
                if (TouchRaycast(Input.mousePosition))
                    return;

            if (Input.GetMouseButton(0))
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x < Screen.width / 2.0f)
                {
                    pantomime.movePlayer.MoveLeft();
                }
                else if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width / 2.0f)
                {
                    pantomime.movePlayer.MoveRight();
                }
            }

        }
    }

    private bool TouchRaycast(Vector3 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red);

        // only cast against UI_LAYER
        int layermask = 1 << Layers.UI_LAYER;
        var hits = Physics.RaycastAll(ray, 50f, layermask);

        foreach (var item in hits)
        {
            IAttraction attraction = item.collider.GetComponentInParent<IAttraction>();
            if (attraction != null)
            {
                return attraction.Execute();
            }

        }
        return false;
    }
}
