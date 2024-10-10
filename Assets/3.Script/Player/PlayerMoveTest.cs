using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    public float moveSpeed = 1f; // 플레이어의 이동 속도

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 입력을 받아서 movement 벡터를 설정합니다.
        movement.x = Input.GetAxisRaw("Horizontal"); // 왼쪽(-1) 또는 오른쪽(+1)
        movement.y = Input.GetAxisRaw("Vertical");   // 아래(-1) 또는 위(+1)
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용해 플레이어를 이동시킵니다.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
