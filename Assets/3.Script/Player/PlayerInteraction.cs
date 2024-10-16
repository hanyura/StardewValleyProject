using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public float interactRange = 0.5f; // �÷��̾� ���� �⺻ �� ĭ(����)
    public KeyCode interactKey = KeyCode.Mouse0; // ���ͷ��� Ű (���콺 ��Ŭ��)

    private Vector2 direction; // �÷��̾ �ٶ󺸴� ����(�� ĭ ��)
    private float currentInteractRange; // ���� ���ͷ��� ���� (���⿡ ���� ��ȭ)

    // �÷��̾ ��� ������ ���� �ִ��� ����
    private void UpdateDirection()
    {
        if (Input.GetKey(KeyCode.W)) // ����
        {
            direction = Vector2.up;
            currentInteractRange = 0.5f; // �⺻ 0.5
        }
        else if (Input.GetKey(KeyCode.S)) // �Ʒ���
        {
            direction = Vector2.down;
            currentInteractRange = 0.7f; // �Ʒ����� 0.7
        }
        else if (Input.GetKey(KeyCode.A)) // ����
        {
            direction = Vector2.left;
            currentInteractRange = 0.5f; // �⺻ 0.5
        }
        else if (Input.GetKey(KeyCode.D)) // ������
        {
            direction = Vector2.right;
            currentInteractRange = 0.5f; // �⺻ 0.5
        }
    }

    void Update()
    {
        // �÷��̾ ���� �ִ� ����� ���� ���ͷ��� ���� ������Ʈ
        UpdateDirection();

        // Ŭ�� �̺�Ʈ ó�� (���콺 ���� ��ư Ŭ�� ��)
        if (Input.GetKeyDown(interactKey))
        {
            // �÷��̾� ���� �� ĭ(����)�� Collider2D�� �ӽ÷� ����
            Vector2 interactPosition = (Vector2)player.position + direction * currentInteractRange + new Vector2(0, -0.5f);

            // �ش� ��ġ�� �ִ� ������Ʈ�� �ִ��� Ȯ�� (Object �±׸� ���� ������Ʈ�� ã��)
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(interactPosition, 0.1f); // 0.1f ũ���� ���� ���� ���

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Object")) // ������Ʈ�� "Object" �±װ� �ִ� ���
                {
                    Destroy(hitCollider.gameObject); // ������Ʈ ����
                }
            }
        }
    }

    // �÷��̾� �տ� �����Ǵ� Collider ������ �ð������� Ȯ���ϱ� ���� Gizmo
    private void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.color = Color.red;
            // Collider�� ��ġ�� �ð������� Ȯ�� (���⿡ ���� interactRange�� �ٸ�)
            Vector2 interactPosition = (Vector2)player.position + direction * currentInteractRange + new Vector2(0, -0.5f);
            Gizmos.DrawWireSphere(interactPosition, 0.1f); // 0.1f ũ���� ���� �� ���·� ǥ��
        }
    }
}
