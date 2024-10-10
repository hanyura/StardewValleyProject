using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 1f; // 레이의 거리
    private Rigidbody2D playerRb; // 플레이어의 Rigidbody2D 컴포넌트
    private Vector2 lastMoveDirection; // 플레이어의 마지막 이동 방향을 저장하는 변수

    private void Awake()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 현재 플레이어의 속도를 가져옵니다.
        Vector2 movement = playerRb.velocity;

        // 플레이어가 움직이고 있는 경우, 마지막 이동 방향을 업데이트합니다.
        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement.normalized;
        }

        // 플레이어의 위치와 마지막 이동 방향으로 레이를 쏩니다.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMoveDirection, rayDistance);

        // 디버그용으로 Scene 뷰에서 레이를 시각화합니다.
        Debug.DrawRay(transform.position, lastMoveDirection * rayDistance, Color.red);

        // 레이가 오브젝트에 닿았을 때
        if (hit.collider != null)
        {
            // 태그가 "Object"인지 확인
            if (hit.collider.CompareTag("Object"))
            {
                Debug.Log("Hit Object with tag 'Object': " + hit.collider.name); // 디버그 로그로 닿은 오브젝트 이름 출력

                // 마우스 왼쪽 버튼을 클릭했을 때 해당 오브젝트를 제거
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.collider.gameObject); // 닿은 오브젝트를 제거
                }
            }
        }
    }
}
