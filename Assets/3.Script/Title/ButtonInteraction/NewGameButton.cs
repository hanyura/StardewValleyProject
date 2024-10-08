using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewGameButton : MonoBehaviour
{
    public Camera cam;
    public GameObject creatCharactor;
    public Button newGameButton;
    public Image titleImage;
    public Button[] buttons;
    public float camMoveDustance = 10f;

    private void Start()
    {
        creatCharactor.gameObject.SetActive(false);
        newGameButton.onClick.AddListener(NewGameButtonClick);
    }

    void NewGameButtonClick()
    {
        Vector3 targetPosition = cam.transform.position + Vector3.left * 10f;
        cam.transform.DOMove(targetPosition, 2f);

        // 타이틀 이미지를 오른쪽으로 10f 이동
        Vector3 title = titleImage.transform.position + Vector3.right * 2000f;
        titleImage.transform.DOMove(title, 2f);

        // New Game 버튼을 오른쪽으로 10f 이동
        Vector3 newbtn = buttons[0].transform.position + Vector3.right * 2000f;
        buttons[0].transform.DOMove(newbtn, 2f);

        // Load Game 버튼을 오른쪽으로 10f 이동
        Vector3 loadbtn = buttons[1].transform.position + Vector3.right * 2000f;
        buttons[1].transform.DOMove(loadbtn, 2f);

        // Exit 버튼을 오른쪽으로 10f 이동
        Vector3 exitbtn = buttons[2].transform.position + Vector3.right * 2000f;
        buttons[2].transform.DOMove(exitbtn, 2f);

        Invoke("ActiveCreat", 2f);
    }
    
    void ActiveCreat()
    {
        creatCharactor.gameObject.SetActive(true);
    }
}
