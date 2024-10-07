using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldColor : MonoBehaviour
{
    public InputField nameInputField; // �̸� �Է��ϴ� InputField
    public Text nameLabel; // �̸� ���� �ִ� �ؽ�Ʈ
    internal object onValueChanged;

    void Start()
    {
        // InputField�� onValueChanged �̺�Ʈ�� ChangeText �޼��带 �߰��մϴ�.
        nameInputField.onValueChanged.AddListener(delegate { ChangeText(nameInputField); });
    }
    // ��ǲ�ʵ���� �ؽ�Ʈ�� �ƹ��� �Է��� ���� �� �����ִ� ���� ���������� ǥ��
    void ChangeText(InputField input)
    {
        // ��ǲ�ʵ尡 ����� ��
        if (string.IsNullOrEmpty(input.text))
        {
            // ���� ������ ������
            nameLabel.color = Color.red;
        }
        else
        {
            // �ƴϸ� ���� ������ ������
            nameLabel.color = Color.black;
        }
    }
}
