using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXIT : MonoBehaviour
{
    public Button exitbutton; // 버튼을 할당할 변수

    void Start()
    {
        // exitbutton에 클릭 이벤트를 추가
        exitbutton.onClick.AddListener(exitButtonClicked);
    }


    // 버튼 클릭 시 실행될 메서드
    void exitButtonClicked()
    {
        // 게임 종료
        Application.Quit();

        // Unity 에디터에서 종료되지 않으므로 디버그 메시지를 출력
        Debug.Log("게임이 종료되었습니다!");
    }
}
