using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HousePlayerMove : MonoBehaviour
{
    // �÷��̾��� X, Y �Է� ���� ������ ����
    private float x;
    private float y;

    // �÷��̾��� Rigidbody2D ������Ʈ�� Animator ������Ʈ�� ������ ����
    private Rigidbody2D playerRb;
    private Animator anim;

    // �ȱ�� �޸��� �ӵ��� �����ϴ� ����
    public float playerWalkSpeed = 1f;
    public float playerRunSpeed = 3f;

    //�޸��� ���¸� Ȯ���ϴ� ����
    private bool isrun;

    private void Awake()
    {
        // Rigidbody2D ������Ʈ�� ������ ����
        playerRb = GetComponent<Rigidbody2D>();
        // Animator ������Ʈ�� ������ ����
        anim = GetComponent<Animator>();
        // ó������ �޸��� ���°� �ƴϹǷ� false�� �ʱ�ȭ
        isrun = false;

        // ���� �� �������� �ٶ󺸰� �ʱ� ����
        anim.SetFloat("LastMoveX", 1f); // �������� �ٶ󺸴� ���·� ����
        anim.SetFloat("LastMoveY", 0f); // ���� ���� ����
    }
    private void Update()
    {
        // �� �����Ӹ��� Move �Լ��� ȣ���Ͽ� �̵� ó��
        Move();
    }
    void Move()
    {
        // �Է� ���� ���� X�� Y ������ �������� ����
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // �޸��� �������� ���ο� ���� �̵� �ӵ� ����
        float moveSpeed = isrun ? playerRunSpeed : playerWalkSpeed;

        // �Է� ���� �̵� �ӵ��� ����Ͽ� Rigidbody2D�� �ӵ��� ����
        playerRb.velocity = new Vector2(x, y).normalized * moveSpeed;

        // �ִϸ����Ϳ� ���� �̵� �ӵ� �� ���� (XInput, YInput)
        anim.SetFloat("XInput", playerRb.velocity.x);
        anim.SetFloat("YInput", playerRb.velocity.y);

        // �÷��̾ �����̰� ���� �� ������ �̵� ������ ����
        if (!x.Equals(0) || !y.Equals(0))
        {
            anim.SetFloat("LastMoveX", x);
            anim.SetFloat("LastMoveY", y);
        }

        // ���� Shift Ű�� ������ �� �޸��� ���·� ��ȯ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // �޸��� ���·� ����
            isrun = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isrun = false;
        }

        // �޸��� ���¿� ���� �ִϸ��̼� ó��
        if (!isrun)
        {
            // �ȱ� ������ �� XInput�� YInput�� �Է� ���� �״�� ����
            anim.SetFloat("XInput", x);
            anim.SetFloat("YInput", y);
        }
        else
        {
            // �޸��� ������ ���� ���� Ʈ���� ���� 2�� ����
            anim.SetFloat("XInput", x * 2f);
            anim.SetFloat("YInput", y * 2f);
        }
    }
}
