using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreatToMenu : MonoBehaviour
{
    public Camera cam;
    public GameObject creatCharactor;
    public Button CreatToMenuButton;
    public Image titleImage;
    public Button[] buttons;
    public float camMoveDustance = 10f;

    private void Start()
    {
        CreatToMenuButton.onClick.AddListener(NewGameButtonClick);
    }

    void NewGameButtonClick()
    {
        DeActiveCreat();
        Vector3 targetPosition = cam.transform.position + Vector3.right * 10f;
        cam.transform.DOMove(targetPosition, 2f);

        // 타이틀 이미지를 오른쪽으로 10f 이동
        Vector3 title = titleImage.transform.position + Vector3.left * 2000f;
        titleImage.transform.DOMove(title, 2f);

        // New Game 버튼을 오른쪽으로 10f 이동
        Vector3 newbtn = buttons[0].transform.position + Vector3.left * 2000f;
        buttons[0].transform.DOMove(newbtn, 2f);

        // Load Game 버튼을 오른쪽으로 10f 이동
        Vector3 loadbtn = buttons[1].transform.position + Vector3.left * 2000f;
        buttons[1].transform.DOMove(loadbtn, 2f);

        // Exit 버튼을 오른쪽으로 10f 이동
        Vector3 exitbtn = buttons[2].transform.position + Vector3.left * 2000f;
        buttons[2].transform.DOMove(exitbtn, 2f);

    }

    void DeActiveCreat()
    {
        creatCharactor.gameObject.SetActive(false);
    }
}
