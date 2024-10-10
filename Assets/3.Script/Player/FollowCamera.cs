using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // ���� ���
    public float speed; // ī�޶� ��� ���� �����̴� �ӵ�
    public Vector2 center; // ī�޶� ������ �� �ִ� ������ �߽�
    public Vector2 size; // ī�޶� ������ �� �ִ� ������ ũ��
    float height; // ī�޶��� ����
    float width; // ī�޶��� �ʺ�

    private void Start()
    {
        // ī�޶��� orthographicSize�� ȭ�� ������ �̿��� ī�޶��� �ʺ�� ���̸� ����մϴ�.
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        // ī�޶��� �̵� ������ �ð������� �����ֱ� ���� Gizmo�� ��� ���ڸ� �׸��ϴ�.
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    private void LateUpdate()
    {
        // ī�޶��� ���� ��ġ���� ����� ��ġ�� ���� �ӵ��� �̵��մϴ� (Lerp ���).
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);

        // X ������ ī�޶� �̵��� �� �ִ� ������ ����մϴ�.
        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        // Y ������ ī�޶� �̵��� �� �ִ� ������ ����մϴ�.
        float ly = size.y * 0.5f - height; // ���⸦ size.x�� �ƴ� size.y�� ����
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        // ������ ī�޶� ��ġ�� �����մϴ�.
        transform.position = new Vector3(clampX, clampY, -10f); // -10f�� ī�޶��� Z �� ��ġ�� ���� (2D������ ���� -10 ���)
    }
}
