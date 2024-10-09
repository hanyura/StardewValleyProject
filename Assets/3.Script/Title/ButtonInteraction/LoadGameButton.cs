using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadGameButton : MonoBehaviour
{
    // ī�޶� ������Ʈ
    public Camera cam;
    // ���� ĳ���� ������Ʈ (�ʱ⿡ ��Ȱ��ȭ��)
    public GameObject loadCharactor;
    // 'Load Game' ��ư
    public Button loadGameButton;
    // Ÿ��Ʋ �̹���
    public Image titleImage;
    // ��ư �迭 (New Game, Load Game, Exit)
    public Button[] buttons;

    private void Start()
    {
        // ĳ���͸� �ʱ⿡�� ��Ȱ��ȭ ���·� ����
        loadCharactor.gameObject.SetActive(false);
        // 'Load Game' ��ư Ŭ�� �� LoadGameButtonClick �޼��� ȣ��
        loadGameButton.onClick.AddListener(LoadGameButtonClick);
    }

    void LoadGameButtonClick()
    {
        // ī�޶� �������� 10f �̵�
        MoveUIElement(cam.transform, Vector3.left * 10f, 2f);
        // Ÿ��Ʋ �̹����� ���������� 2000f �̵�
        MoveUIElement(titleImage.transform, Vector3.right * 2000f, 2f);

        // �� ��ư�� ���������� 2000f �̵�
        for (int i = 0; i < buttons.Length; i++)
        {
            MoveUIElement(buttons[i].transform, Vector3.right * 2000f, 2f);
        }

        // 2�� �� ActivateCharacter �޼��� ȣ��
        Invoke("ActivateCharacter", 2f);
    }

    void MoveUIElement(Transform element, Vector3 offset, float duration)
    {
        Vector3 targetPosition = element.position + offset;
        element.DOMove(targetPosition, duration);
    }

    void ActivateCharacter()
    {
        // ĳ���͸� Ȱ��ȭ
        loadCharactor.gameObject.SetActive(true);
    }
}
