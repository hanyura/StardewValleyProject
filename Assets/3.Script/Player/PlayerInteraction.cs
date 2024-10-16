using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float interactRange = 0.5f; // 플레이어 앞의 기본 한 칸(범위)
    public KeyCode interactKey = KeyCode.Mouse0; // 인터랙션 키 (마우스 좌클릭)

    private Vector2 direction; // 플레이어가 바라보는 방향(한 칸 앞)
    private float currentInteractRange; // 현재 인터랙션 범위 (방향에 따라 변화)

    // 플레이어가 어느 방향을 보고 있는지 결정
    private void UpdateDirection()
    {
        if (Input.GetKey(KeyCode.W)) // 위쪽
        {
            direction = Vector2.up;
            currentInteractRange = 0.5f; // 기본 0.5
        }
        else if (Input.GetKey(KeyCode.S)) // 아래쪽
        {
            direction = Vector2.down;
            currentInteractRange = 0.7f; // 아래쪽은 0.7
        }
        else if (Input.GetKey(KeyCode.A)) // 왼쪽
        {
            direction = Vector2.left;
            currentInteractRange = 0.5f; // 기본 0.5
        }
        else if (Input.GetKey(KeyCode.D)) // 오른쪽
        {
            direction = Vector2.right;
            currentInteractRange = 0.5f; // 기본 0.5
        }
    }

    void Update()
    {
        // 플레이어가 보고 있는 방향과 현재 인터랙션 범위 업데이트
        UpdateDirection();

        // 클릭 이벤트 처리 (마우스 왼쪽 버튼 클릭 시)
        if (Input.GetKeyDown(interactKey))
        {
            // 플레이어 앞의 한 칸(범위)에 Collider2D를 임시로 생성
            Vector2 interactPosition = (Vector2)player.position + direction * currentInteractRange + new Vector2(0, -0.5f);

            // 해당 위치에 있는 오브젝트가 있는지 확인 (Object 태그를 가진 오브젝트만 찾음)
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(interactPosition, 0.1f); // 0.1f 크기의 작은 범위 사용

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Object")) // 오브젝트에 "Object" 태그가 있는 경우
                {
                    Destroy(hitCollider.gameObject); // 오브젝트 삭제
                }
            }
        }
    }

    // 플레이어 앞에 생성되는 Collider 영역을 시각적으로 확인하기 위한 Gizmo
    private void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.color = Color.red;
            // Collider의 위치를 시각적으로 확인 (방향에 따라 interactRange가 다름)
            Vector2 interactPosition = (Vector2)player.position + direction * currentInteractRange + new Vector2(0, -0.5f);
            Gizmos.DrawWireSphere(interactPosition, 0.1f); // 0.1f 크기의 작은 구 형태로 표시
        }
    }
}
