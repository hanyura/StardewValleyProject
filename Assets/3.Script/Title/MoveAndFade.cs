using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveAndFade : MonoBehaviour
{
    public Camera cam;               // 메인 카메라
    public Button whiteImage;        // 흰색 페이드 아웃 화면 버튼
    public Image titleImage;         // 타이틀 이미지
    public Button[] creatButtons;    // 생성 버튼들
    private Vector2 titlePos;        // 타이틀 이미지의 원래 위치를 저장

    private void Start()
    {
        // 카메라 이동 애니메이션 호출
        CameraMove();

        // 타이틀 이미지의 원래 위치 저장
        titlePos = titleImage.rectTransform.anchoredPosition;

        // 타이틀 이미지를 화면 밖으로 이동시킴
        titleImage.rectTransform.anchoredPosition = new Vector2(titlePos.x, 1000f);

        // whiteImage 버튼 클릭 시 애니메이션 스킵 설정
        whiteImage.onClick.AddListener(SkipMoveAnimation);

        // 버튼과 페이드 애니메이션 시작
        VisibleButton();
        FadeScreen();

        // 일정 시간 후 타이틀 이미지와 화면 제거 실행
        Invoke("ReMoveTitleImage", 7f);
        Invoke("DestroyScreen", 10f);
    }

    void CameraMove()
    {
        // 현재 오브젝트에 카메라가 없다면 오류 메시지 출력 후 종료
        if (cam == null)
        {
            Debug.LogError("카메라가 할당되지 않았습니다. Inspector에서 카메라를 설정하세요.");
            return;
        }
        // 카메라를 7초 후 Y축으로 8초 동안 이동
        cam.transform.DOMove(new Vector3(0, 7.3f, -1), 8f).SetDelay(7f);
    }

    void FadeScreen()
    {
        // 흰색 화면의 알파값을 3초 동안 0으로 만듦
        whiteImage.GetComponent<Image>().DOFade(0f, 3f);
    }

    void DestroyScreen()
    {
        // 흰색 화면을 비활성화하여 제거
        whiteImage.gameObject.SetActive(false);
    }

    void SkipMoveAnimation()
    {
        // 버튼과 타이틀 이미지를 즉시 활성화 및 이동시킴
        ActiveButton0();
        ReMoveTitleImage();

        // 모든 애니메이션을 즉시 완료
        DOTween.CompleteAll();

        // 화면 제거
        DestroyScreen();
    }

    void VisibleButton()
    {
        // 버튼들을 초기 상태로 비활성화
        for (int i = 0; i < creatButtons.Length; i++)
        {
            creatButtons[i].gameObject.SetActive(false);
        }
        // 15초 후 버튼 활성화 애니메이션 호출
        Invoke("ActiveButton0", 15f);
    }

    void ActiveButton0()
    {
        // 첫 번째 버튼 활성화
        creatButtons[0].gameObject.SetActive(true);
        // 다음 버튼 활성화 호출
        Invoke("ActiveButton1", 0.5f);
        Invoke("ActiveButton2", 1f);
    }

    void ActiveButton1()
    {
        // 두 번째 버튼 활성화
        creatButtons[1].gameObject.SetActive(true);
    }

    void ActiveButton2()
    {
        // 세 번째 버튼 활성화
        creatButtons[2].gameObject.SetActive(true);
    }

    void ReMoveTitleImage()
    {
        // 타이틀 이미지를 8초 동안 원래 위치로 이동
        titleImage.rectTransform.DOAnchorPos(titlePos, 8f).SetEase(Ease.Linear);
    }
}
