using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveAndFade : MonoBehaviour
{
    public Camera cam;               // ���� ī�޶�
    public Button whiteImage;        // ��� ���̵� �ƿ� ȭ�� ��ư
    public Image titleImage;         // Ÿ��Ʋ �̹���
    public Button[] creatButtons;    // ���� ��ư��
    private Vector2 titlePos;        // Ÿ��Ʋ �̹����� ���� ��ġ�� ����

    private void Start()
    {
        // ī�޶� �̵� �ִϸ��̼� ȣ��
        CameraMove();

        // Ÿ��Ʋ �̹����� ���� ��ġ ����
        titlePos = titleImage.rectTransform.anchoredPosition;

        // Ÿ��Ʋ �̹����� ȭ�� ������ �̵���Ŵ
        titleImage.rectTransform.anchoredPosition = new Vector2(titlePos.x, 1000f);

        // whiteImage ��ư Ŭ�� �� �ִϸ��̼� ��ŵ ����
        whiteImage.onClick.AddListener(SkipMoveAnimation);

        // ��ư�� ���̵� �ִϸ��̼� ����
        VisibleButton();
        FadeScreen();

        // ���� �ð� �� Ÿ��Ʋ �̹����� ȭ�� ���� ����
        Invoke("ReMoveTitleImage", 7f);
        Invoke("DestroyScreen", 10f);
    }

    void CameraMove()
    {
        // ���� ������Ʈ�� ī�޶� ���ٸ� ���� �޽��� ��� �� ����
        if (cam == null)
        {
            Debug.LogError("ī�޶� �Ҵ���� �ʾҽ��ϴ�. Inspector���� ī�޶� �����ϼ���.");
            return;
        }
        // ī�޶� 7�� �� Y������ 8�� ���� �̵�
        cam.transform.DOMove(new Vector3(0, 7.3f, -1), 8f).SetDelay(7f);
    }

    void FadeScreen()
    {
        // ��� ȭ���� ���İ��� 3�� ���� 0���� ����
        whiteImage.GetComponent<Image>().DOFade(0f, 3f);
    }

    void DestroyScreen()
    {
        // ��� ȭ���� ��Ȱ��ȭ�Ͽ� ����
        whiteImage.gameObject.SetActive(false);
    }

    void SkipMoveAnimation()
    {
        // ��ư�� Ÿ��Ʋ �̹����� ��� Ȱ��ȭ �� �̵���Ŵ
        ActiveButton0();
        ReMoveTitleImage();

        // ��� �ִϸ��̼��� ��� �Ϸ�
        DOTween.CompleteAll();

        // ȭ�� ����
        DestroyScreen();
    }

    void VisibleButton()
    {
        // ��ư���� �ʱ� ���·� ��Ȱ��ȭ
        for (int i = 0; i < creatButtons.Length; i++)
        {
            creatButtons[i].gameObject.SetActive(false);
        }
        // 15�� �� ��ư Ȱ��ȭ �ִϸ��̼� ȣ��
        Invoke("ActiveButton0", 15f);
    }

    void ActiveButton0()
    {
        // ù ��° ��ư Ȱ��ȭ
        creatButtons[0].gameObject.SetActive(true);
        // ���� ��ư Ȱ��ȭ ȣ��
        Invoke("ActiveButton1", 0.5f);
        Invoke("ActiveButton2", 1f);
    }

    void ActiveButton1()
    {
        // �� ��° ��ư Ȱ��ȭ
        creatButtons[1].gameObject.SetActive(true);
    }

    void ActiveButton2()
    {
        // �� ��° ��ư Ȱ��ȭ
        creatButtons[2].gameObject.SetActive(true);
    }

    void ReMoveTitleImage()
    {
        // Ÿ��Ʋ �̹����� 8�� ���� ���� ��ġ�� �̵�
        titleImage.rectTransform.DOAnchorPos(titlePos, 8f).SetEase(Ease.Linear);
    }
}
