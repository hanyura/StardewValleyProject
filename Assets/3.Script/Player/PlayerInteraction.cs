using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 1f; // ������ �Ÿ�
    private Rigidbody2D playerRb; // �÷��̾��� Rigidbody2D ������Ʈ
    private Vector2 lastMoveDirection; // �÷��̾��� ������ �̵� ������ �����ϴ� ����

    private void Awake()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ���� �÷��̾��� �ӵ��� �����ɴϴ�.
        Vector2 movement = playerRb.velocity;

        // �÷��̾ �����̰� �ִ� ���, ������ �̵� ������ ������Ʈ�մϴ�.
        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement.normalized;
        }

        // �÷��̾��� ��ġ�� ������ �̵� �������� ���̸� ���ϴ�.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMoveDirection, rayDistance);

        // ����׿����� Scene �信�� ���̸� �ð�ȭ�մϴ�.
        Debug.DrawRay(transform.position, lastMoveDirection * rayDistance, Color.red);

        // ���̰� ������Ʈ�� ����� ��
        if (hit.collider != null)
        {
            // �±װ� "Object"���� Ȯ��
            if (hit.collider.CompareTag("Object"))
            {
                Debug.Log("Hit Object with tag 'Object': " + hit.collider.name); // ����� �α׷� ���� ������Ʈ �̸� ���

                // ���콺 ���� ��ư�� Ŭ������ �� �ش� ������Ʈ�� ����
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.collider.gameObject); // ���� ������Ʈ�� ����
                }
            }
        }
    }
}
