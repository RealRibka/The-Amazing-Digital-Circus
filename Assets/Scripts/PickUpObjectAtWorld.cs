using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectAtWorld : MonoBehaviour, IInteract
{
    public bool isCurrentlyPickedUp { get; private set; }
    private Vector3 offset;

    public void Action()
    {
        isCurrentlyPickedUp = !isCurrentlyPickedUp;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        if (isCurrentlyPickedUp)
        {
            // Получаем позицию мыши в мировых координатах с учетом глубины нажатия
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (Camera.main.transform.position.z - transform.position.z)));
            Vector3 camPos = Camera.main.transform.position;

            float X = Math.Clamp(mousePosition.x, -2, 2);
            float Y = Math.Clamp(mousePosition.y, -2, 2);
            float Z = Math.Clamp(mousePosition.z, -2, 2);
            // Устанавливаем новую позицию объекта с уч.етом глубины нажатия
            transform.position = new Vector3(camPos.x - X, camPos.y + Y, camPos.z - Z) + offset;
        }
    }
}
