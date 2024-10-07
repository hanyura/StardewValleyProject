using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    public Button quitButton; // ��ư�� �Ҵ��� ����

    void Start()
    {
        // quitButton�� Ŭ�� �̺�Ʈ�� �߰�
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    // ��ư Ŭ�� �� ����� �޼���
    void OnQuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("������ ����Ǿ����ϴ�!"); // Unity �����Ϳ����� ������� �����Ƿ� ����� �޽����� ���
    }
}
