using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HousePlayerMove : MonoBehaviour
{
    // 플레이어의 X, Y 입력 값을 저장할 변수
    private float x;
    private float y;

    // 플레이어의 Rigidbody2D 컴포넌트와 Animator 컴포넌트를 저장할 변수
    private Rigidbody2D playerRb;
    private Animator anim;

    // 걷기와 달리기 속도를 저장하는 변수
    public float playerWalkSpeed = 1f;
    public float playerRunSpeed = 3f;

    //달리기 상태를 확인하는 변수
    private bool isrun;

    private void Awake()
    {
        // Rigidbody2D 컴포넌트를 가져와 저장
        playerRb = GetComponent<Rigidbody2D>();
        // Animator 컴포넌트를 가져와 저장
        anim = GetComponent<Animator>();
        // 처음에는 달리기 상태가 아니므로 false로 초기화
        isrun = false;

        // 시작 시 오른쪽을 바라보게 초기 설정
        anim.SetFloat("LastMoveX", 1f); // 오른쪽을 바라보는 상태로 설정
        anim.SetFloat("LastMoveY", 0f); // 수직 방향 없음
    }
    private void Update()
    {
        // 매 프레임마다 Move 함수를 호출하여 이동 처리
        Move();
    }
    void Move()
    {
        // 입력 값에 따라 X와 Y 방향의 움직임을 저장
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // 달리기 상태인지 여부에 따라 이동 속도 설정
        float moveSpeed = isrun ? playerRunSpeed : playerWalkSpeed;

        // 입력 값과 이동 속도를 사용하여 Rigidbody2D의 속도를 설정
        playerRb.velocity = new Vector2(x, y).normalized * moveSpeed;

        // 애니메이터에 현재 이동 속도 값 전달 (XInput, YInput)
        anim.SetFloat("XInput", playerRb.velocity.x);
        anim.SetFloat("YInput", playerRb.velocity.y);

        // 플레이어가 움직이고 있을 때 마지막 이동 방향을 저장
        if (!x.Equals(0) || !y.Equals(0))
        {
            anim.SetFloat("LastMoveX", x);
            anim.SetFloat("LastMoveY", y);
        }

        // 왼쪽 Shift 키를 눌렀을 때 달리기 상태로 전환
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // 달리기 상태로 설정
            isrun = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isrun = false;
        }

        // 달리기 상태에 따른 애니메이션 처리
        if (!isrun)
        {
            // 걷기 상태일 때 XInput과 YInput에 입력 값을 그대로 전달
            anim.SetFloat("XInput", x);
            anim.SetFloat("YInput", y);
        }
        else
        {
            // 달리기 상태일 때는 블렌드 트리의 값을 2로 설정
            anim.SetFloat("XInput", x * 2f);
            anim.SetFloat("YInput", y * 2f);
        }
    }
}
