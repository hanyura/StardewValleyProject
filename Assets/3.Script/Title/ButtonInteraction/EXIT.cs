using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXIT : MonoBehaviour
{
    public Button exitbutton; // ��ư�� �Ҵ��� ����

    void Start()
    {
        // exitbutton�� Ŭ�� �̺�Ʈ�� �߰�
        exitbutton.onClick.AddListener(exitButtonClicked);
    }


    // ��ư Ŭ�� �� ����� �޼���
    void exitButtonClicked()
    {
        // ���� ����
        Application.Quit();

        // Unity �����Ϳ��� ������� �����Ƿ� ����� �޽����� ���
        Debug.Log("������ ����Ǿ����ϴ�!");
    }
}
