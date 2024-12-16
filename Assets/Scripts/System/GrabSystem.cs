using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public Transform handTransform; // Позиция руки
    protected GameObject heldItem;  // Текущий предмет в руке

    // Метод для поднятия предмета
    public void PickUpItem(GameObject item)
    {
        if (heldItem != null)
        {
            Debug.Log("Уже есть предмет в руке!");
            return; // Если предмет уже есть, не берем другой
        }

        // Отключаем физику у предмета
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        // Устанавливаем родительский объект и перемещаем в руку
        item.transform.SetParent(handTransform);
        item.transform.localPosition = Vector3.zero;
        //item.transform.localRotation = Quaternion.identity;

        heldItem = item; // Сохраняем текущий предмет
        Debug.Log("Предмет взят: " + item.name);
    }

    // Метод для выброса предмета
    public void DropItem()
    {
        if (heldItem != null)
        {
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            heldItem.transform.SetParent(null);
            heldItem = null; // Очищаем текущий предмет

            Debug.Log("Предмет выброшен.");
        }
    }
}
