using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldColor : MonoBehaviour
{
    public InputField nameInputField; // 이름 입력하는 InputField
    public Text nameLabel; // 이름 옆에 있는 텍스트
    internal object onValueChanged;

    void Start()
    {
        // InputField의 onValueChanged 이벤트에 ChangeText 메서드를 추가합니다.
        nameInputField.onValueChanged.AddListener(delegate { ChangeText(nameInputField); });
    }
    // 인풋필드상의 텍스트에 아무런 입력이 없을 시 옆에있는 라벨은 붉은색으로 표시
    void ChangeText(InputField input)
    {
        // 인풋필드가 비었을 시
        if (string.IsNullOrEmpty(input.text))
        {
            // 라벨의 색상은 붉은색
            nameLabel.color = Color.red;
        }
        else
        {
            // 아니면 라벨의 색상은 검은색
            nameLabel.color = Color.black;
        }
    }
}
