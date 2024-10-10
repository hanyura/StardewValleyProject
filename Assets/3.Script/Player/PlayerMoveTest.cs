using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    public float moveSpeed = 1f; // �÷��̾��� �̵� �ӵ�

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �Է��� �޾Ƽ� movement ���͸� �����մϴ�.
        movement.x = Input.GetAxisRaw("Horizontal"); // ����(-1) �Ǵ� ������(+1)
        movement.y = Input.GetAxisRaw("Vertical");   // �Ʒ�(-1) �Ǵ� ��(+1)
    }

    void FixedUpdate()
    {
        // Rigidbody2D�� ����� �÷��̾ �̵���ŵ�ϴ�.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
