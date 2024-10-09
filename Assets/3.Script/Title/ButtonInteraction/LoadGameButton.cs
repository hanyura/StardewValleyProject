using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadGameButton : MonoBehaviour
{
    // 카메라 오브젝트
    public Camera cam;
    // 게임 캐릭터 오브젝트 (초기에 비활성화됨)
    public GameObject loadCharactor;
    // 'Load Game' 버튼
    public Button loadGameButton;
    // 타이틀 이미지
    public Image titleImage;
    // 버튼 배열 (New Game, Load Game, Exit)
    public Button[] buttons;

    private void Start()
    {
        // 캐릭터를 초기에는 비활성화 상태로 설정
        loadCharactor.gameObject.SetActive(false);
        // 'Load Game' 버튼 클릭 시 LoadGameButtonClick 메서드 호출
        loadGameButton.onClick.AddListener(LoadGameButtonClick);
    }

    void LoadGameButtonClick()
    {
        // 카메라를 왼쪽으로 10f 이동
        MoveUIElement(cam.transform, Vector3.left * 10f, 2f);
        // 타이틀 이미지를 오른쪽으로 2000f 이동
        MoveUIElement(titleImage.transform, Vector3.right * 2000f, 2f);

        // 각 버튼을 오른쪽으로 2000f 이동
        for (int i = 0; i < buttons.Length; i++)
        {
            MoveUIElement(buttons[i].transform, Vector3.right * 2000f, 2f);
        }

        // 2초 후 ActivateCharacter 메서드 호출
        Invoke("ActivateCharacter", 2f);
    }

    void MoveUIElement(Transform element, Vector3 offset, float duration)
    {
        Vector3 targetPosition = element.position + offset;
        element.DOMove(targetPosition, duration);
    }

    void ActivateCharacter()
    {
        // 캐릭터를 활성화
        loadCharactor.gameObject.SetActive(true);
    }
}
