using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // 따라갈 대상
    public float speed; // 카메라가 대상에 따라 움직이는 속도
    public Vector2 center; // 카메라가 움직일 수 있는 범위의 중심
    public Vector2 size; // 카메라가 움직일 수 있는 범위의 크기
    float height; // 카메라의 높이
    float width; // 카메라의 너비

    private void Start()
    {
        // 카메라의 orthographicSize와 화면 비율을 이용해 카메라의 너비와 높이를 계산합니다.
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        // 카메라의 이동 범위를 시각적으로 보여주기 위해 Gizmo로 경계 상자를 그립니다.
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    private void LateUpdate()
    {
        // 카메라의 현재 위치에서 대상의 위치로 일정 속도로 이동합니다 (Lerp 사용).
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);

        // X 축으로 카메라가 이동할 수 있는 범위를 계산합니다.
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        // Y 축으로 카메라가 이동할 수 있는 범위를 계산합니다.
        float ly = size.y * 0.5f - height; // 여기를 size.x가 아닌 size.y로 수정
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        // 수정된 카메라 위치를 적용합니다.
        transform.position = new Vector3(clampX, clampY, -10f); // -10f는 카메라의 Z 축 위치를 설정 (2D에서는 보통 -10 사용)
    }
}
