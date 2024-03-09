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
            Debug.LogError("�� �� �������� � ������ CameraSize ������� ������ ��� ������");
            return;
        }

        RectTransform buttonRectTransform = targetButton.GetComponent<RectTransform>();

        // ������������ ������ ������ ��� ������ ������
        buttonRectTransform.sizeDelta = new Vector2(targetCamera.orthographicSize * 2f * targetCamera.aspect,targetCamera.orthographicSize * 2f);
    }
}


