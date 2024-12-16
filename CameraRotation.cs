using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @class CameraRotationInfo
 * @brief Базовый класс, содержащий параметры и ссылки для управления камерой.
 */
public class CameraRotationInfo : MonoBehaviour
{
    /** @brief Чувствительность мыши для вращения камеры. */
    public float mouseSense = 2f;

    /** @brief Максимальный угол поворота камеры по вертикали. */
    protected float yMaxAngle = 80f;

    /** @brief Текущий угол поворота камеры по вертикали. */
    protected float rotationX = .0f;

    /** @brief Максимальная дистанция для взаимодействия с объектами. */
    protected float interactionDistance = 3f;

    /** @brief Ссылка на камеру, используемую скриптом. */
    protected Camera cam;

    /** @brief Ссылка на объект игрока. */
    public Player player;

    /** @brief Ссылка на пользовательский интерфейс для подсказок. */
    public UIHelpSystem UI;
}

/**
 * @class CameraRotation
 * @brief Класс управления камерой игрока и взаимодействия с объектами.
 * Наследуется от CameraRotationInfo.
 */
public class CameraRotation : CameraRotationInfo
{
    /**
     * @brief Метод, вызываемый при старте объекта.
     * Выполняет начальную настройку камеры и игрока.
     */
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; ///< Блокирует курсор внутри окна.
        Cursor.visible = false; ///< Скрывает курсор мыши.

        cam = GetComponent<Camera>(); ///< Получение ссылки на компонент камеры.
        player = GetComponentInParent<Player>(); ///< Поиск объекта игрока в родительских объектах.
    }

    /**
     * @brief Метод, вызываемый каждый кадр.
     * Выполняет управление камерой и взаимодействие с объектами.
     */
    void Update()
    {
        Rotation(); ///< Управление вращением камеры.
        InteractWithObject(); ///< Проверка взаимодействия с объектами.
    }

    /**
     * @brief Управление вращением камеры в зависимости от движения мыши.
     */
    void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X"); ///< Получение ввода по оси X мыши.
        float mouseY = Input.GetAxis("Mouse Y"); ///< Получение ввода по оси Y мыши.

        transform.parent.Rotate(Vector3.up * mouseX * mouseSense); ///< Вращение игрока по горизонтали.

        rotationX -= mouseY * mouseSense; ///< Изменение угла по вертикали.
        rotationX = Mathf.Clamp(rotationX, -yMaxAngle, yMaxAngle); ///< Ограничение угла по вертикали.
        transform.localRotation = Quaternion.Euler(rotationX, .0f, .0f); ///< Применение вращения камеры.
    }

    /**
     * @brief Проверяет возможность взаимодействия игрока с объектами и обрабатывает взаимодействие.
     */
    private void InteractWithObject()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); ///< Создание луча из позиции камеры.

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance)) ///< Проверка пересечения луча с объектами.
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>(); ///< Проверка наличия интерфейса IInteractable у объекта.

            if (interactable != null)
            {
                UI.actionHelp.enabled = true; ///< Включение подсказки во время наведения на объект.

                if (Input.GetKeyDown(KeyCode.E)) ///< Проверка нажатия клавиши взаимодействия.
                {
                    interactable.Interact(player); ///< Вызов метода взаимодействия у объекта.
                }
            }
        }
        else
        {
            UI.actionHelp.enabled = false; ///< Отключение подсказки, если объект не найден.
        }
    }
}
