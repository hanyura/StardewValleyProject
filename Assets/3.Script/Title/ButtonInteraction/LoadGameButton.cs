using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadGameButton : MonoBehaviour
{
    public Camera cam;
    public GameObject loadCharactor;
    public Button loadGameButton;
    public Image titleImage;
    public Button[] buttons;

    private void Start()
    {
        loadCharactor.gameObject.SetActive(false);
        loadGameButton.onClick.AddListener(LoadGameButtonClick);
    }

    void LoadGameButtonClick()
    {
        Vector3 targetPosition = cam.transform.position + Vector3.left * 10f;
        cam.transform.DOMove(targetPosition, 2f);

        // Ÿ��Ʋ �̹����� ���������� 10f �̵�
        Vector3 title = titleImage.transform.position + Vector3.right * 2000f;
        titleImage.transform.DOMove(title, 2f);

        // New Game ��ư�� ���������� 10f �̵�
        Vector3 newbtn = buttons[0].transform.position + Vector3.right * 2000f;
        buttons[0].transform.DOMove(newbtn, 2f);

        // Load Game ��ư�� ���������� 10f �̵�
        Vector3 loadbtn = buttons[1].transform.position + Vector3.right * 2000f;
        buttons[1].transform.DOMove(loadbtn, 2f);

        // Exit ��ư�� ���������� 10f �̵�
        Vector3 exitbtn = buttons[2].transform.position + Vector3.right * 2000f;
        buttons[2].transform.DOMove(exitbtn, 2f);

        Invoke("ActiveCreat", 2f);
    }

    void ActiveCreat()
    {
        loadCharactor.gameObject.SetActive(true);
    }
}
