using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    public Button quitButton; // 버튼을 할당할 변수

    void Start()
    {
        // quitButton에 클릭 이벤트를 추가
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    // 버튼 클릭 시 실행될 메서드
    void OnQuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("게임이 종료되었습니다!"); // Unity 에디터에서는 종료되지 않으므로 디버그 메시지를 출력
    }
}
