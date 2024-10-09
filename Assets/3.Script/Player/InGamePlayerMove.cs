using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerMove : MonoBehaviour
{
    // 플레이어의 X,Y 입력 값을 저장할 변수
    private float X;
    private float Y;

    // 플레이어의 Rigidbody2D 컴포넌트와 Animator 컴포넌트를 저장할 변수
    private Rigidbody2D playerRigid;
    private Animator animator;

    //걷기와 달리기 속도를 저장하는 변수
    public float playerWalkSpeed = 1f;
    public float playerRunSpeed = 3f;

    //달리기 상태를 확인하는 변수
    private bool isRun;

    // 현재 활성화된 애니메이션 트리거를 저장하는 변수
    private string currentTrigger;

    // 현재 재생중인 트리거 애니메이션 작동 시 다른 작동을 막는 변수
    private bool isActionPlay;

    // 플레이어의 현재 위치를 저장할 변수
    private Vector3 fixedPosition;

    private void Awake()
    {
        // Rigidbody2D 컴포넌트를 가져와 저장
        playerRigid = GetComponent<Rigidbody2D>();

        // Animator 컴포넌트를 가져와 저장
        animator = GetComponent<Animator>();

        // 처음에는 달리기 상태가 아니므로 false로 초기화
        isRun = false;

        // 시작 시 정면을 바라보게 설정
        animator.SetFloat("LastMoveX", 0f); // 수평 방향 없음
        animator.SetFloat("LastMoveY", -1f); // 정면을 바라보는 상태로 설정

        // 초기에는 트리거가 없으므로 null로 설정
        currentTrigger = null;

        // 초기에는 애니메이션이 재생 중이 아니므로 false로 설정
        isActionPlay = false;
    }

    private void Update()
    {
        // 애니메이션 중일 때 이동 및 입력을 막음
        if (!isActionPlay)
        {
            PlayerMove(); // 플레이어 이동 처리
            CheckInput(); // 입력 체크 및 트리거 설정
        }
        else
        {
            // 애니메이션이 재생 중일 때는 플레이어 위치를 고정
            transform.position = fixedPosition;
        }

    }

    void PlayerMove()
    {
        // 애니메이션 중일 때 이동을 막음
        if (isActionPlay) return;

        // 입력 값에 따라 X와 Y방향의 움직임을 저장
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");

        // 달리기 상태인지 여부에 따라 이동 속도 설정
        float moveSpeed = isRun ? playerRunSpeed : playerWalkSpeed;

        // 입력 값과 이동 속도를 사용하여 Rigidbody2D의 속도를 설정
        playerRigid.velocity = new Vector2(X, Y).normalized * moveSpeed;

        // 애니메이터에 현재 이동 속도 값 전달 (XInput, YInput)
        animator.SetFloat("XInput", playerRigid.velocity.x);
        animator.SetFloat("YInput", playerRigid.velocity.y);

        // 플레이어가 움직이고 있을 때 마지막 이동 방향을 저장
        if (!X.Equals(0) || !Y.Equals(0))
        {
            animator.SetFloat("LastMoveX", X);
            animator.SetFloat("LastMoveY", Y);
        }

        // 왼쪽 Shift 키를 눌렀을 때 달리기 상태로 전환
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // 달리기 상태로 설정
            isRun = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // 달리기 상태 해제
            isRun = false;
        }

        // 달리기 상태에 따른 애니메이션 처리
        if (!isRun)
        {
            // 걷기 상태일 때 XInput과 YInput에 입력 값을 그대로 전달
            animator.SetFloat("XInput", X);
            animator.SetFloat("YInput", Y);
        }
        else
        {
            // 달리기 상태일 때는 블렌드 트리의 값을 2로 설정
            animator.SetFloat("XInput", X * 2f);
            animator.SetFloat("YInput", Y * 2f);
        }

        // 마우스 왼쪽 버튼을 클릭했을 때, 현재 트리거가 설정되어 있으면 해당 트리거 실행
        if (Input.GetMouseButtonDown(0) && currentTrigger != null && !isActionPlay)
        {
            // 애니메이션이 재생 중이 아니면 트리거 실행
            if (!isActionPlay)
            {
                // 현재 위치 저장
                fixedPosition = transform.position;

                animator.SetTrigger(currentTrigger); // 트리거 애니메이션 실행
                isActionPlay = true; // 애니메이션 재생 중으로 설정
            }
        }
    }

    void CheckInput()
    {
        // 숫자 1 키를 눌렀을 때 트리거를 "Axe"로 설정
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTrigger = "Axe";
        }
        // 숫자 2 키를 눌렀을 때 트리거를 "Pick"로 설정
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTrigger = "Pick";
        }
        // 숫자 3 키를 눌렀을 때 트리거를 "Water"로 설정
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTrigger = "Water";
        }
        // 숫자 4 키를 눌렀을 때 트리거를 "Slice"로 설정
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentTrigger = "Slice";
        }
    }

    // 애니메이션이 끝날 때 호출될 메서드
    public void OnAnimationEnd()
    {
        isActionPlay = false; // 애니메이션이 끝나면 움직임과 입력을 다시 허용
    }
}