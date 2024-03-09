using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSize : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private Button targetButton;

    private void Start()
    {
        if (targetCamera == null || targetButton == null)
        {
            Debug.LogError("Вы не добавили в скрипт CameraSize объекты камеры или кнопки");
            return;
        }

        RectTransform buttonRectTransform = targetButton.GetComponent<RectTransform>();

        // Подстраиваем размер кнопки под размер камеры
        buttonRectTransform.sizeDelta = new Vector2(targetCamera.orthographicSize * 2f * targetCamera.aspect,targetCamera.orthographicSize * 2f);
    }
}


