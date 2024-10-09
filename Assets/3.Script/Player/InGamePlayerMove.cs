using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerMove : MonoBehaviour
{
    // �÷��̾��� X,Y �Է� ���� ������ ����
    private float X;
    private float Y;

    // �÷��̾��� Rigidbody2D ������Ʈ�� Animator ������Ʈ�� ������ ����
    private Rigidbody2D playerRigid;
    private Animator animator;

    //�ȱ�� �޸��� �ӵ��� �����ϴ� ����
    public float playerWalkSpeed = 1f;
    public float playerRunSpeed = 3f;

    //�޸��� ���¸� Ȯ���ϴ� ����
    private bool isRun;

    // ���� Ȱ��ȭ�� �ִϸ��̼� Ʈ���Ÿ� �����ϴ� ����
    private string currentTrigger;

    // ���� ������� Ʈ���� �ִϸ��̼� �۵� �� �ٸ� �۵��� ���� ����
    private bool isActionPlay;

    // �÷��̾��� ���� ��ġ�� ������ ����
    private Vector3 fixedPosition;

    private void Awake()
    {
        // Rigidbody2D ������Ʈ�� ������ ����
        playerRigid = GetComponent<Rigidbody2D>();

        // Animator ������Ʈ�� ������ ����
        animator = GetComponent<Animator>();

        // ó������ �޸��� ���°� �ƴϹǷ� false�� �ʱ�ȭ
        isRun = false;

        // ���� �� ������ �ٶ󺸰� ����
        animator.SetFloat("LastMoveX", 0f); // ���� ���� ����
        animator.SetFloat("LastMoveY", -1f); // ������ �ٶ󺸴� ���·� ����

        // �ʱ⿡�� Ʈ���Ű� �����Ƿ� null�� ����
        currentTrigger = null;

        // �ʱ⿡�� �ִϸ��̼��� ��� ���� �ƴϹǷ� false�� ����
        isActionPlay = false;
    }

    private void Update()
    {
        // �ִϸ��̼� ���� �� �̵� �� �Է��� ����
        if (!isActionPlay)
        {
            PlayerMove(); // �÷��̾� �̵� ó��
            CheckInput(); // �Է� üũ �� Ʈ���� ����
        }
        else
        {
            // �ִϸ��̼��� ��� ���� ���� �÷��̾� ��ġ�� ����
            transform.position = fixedPosition;
        }

    }

    void PlayerMove()
    {
        // �ִϸ��̼� ���� �� �̵��� ����
        if (isActionPlay) return;

        // �Է� ���� ���� X�� Y������ �������� ����
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");

        // �޸��� �������� ���ο� ���� �̵� �ӵ� ����
        float moveSpeed = isRun ? playerRunSpeed : playerWalkSpeed;

        // �Է� ���� �̵� �ӵ��� ����Ͽ� Rigidbody2D�� �ӵ��� ����
        playerRigid.velocity = new Vector2(X, Y).normalized * moveSpeed;

        // �ִϸ����Ϳ� ���� �̵� �ӵ� �� ���� (XInput, YInput)
        animator.SetFloat("XInput", playerRigid.velocity.x);
        animator.SetFloat("YInput", playerRigid.velocity.y);

        // �÷��̾ �����̰� ���� �� ������ �̵� ������ ����
        if (!X.Equals(0) || !Y.Equals(0))
        {
            animator.SetFloat("LastMoveX", X);
            animator.SetFloat("LastMoveY", Y);
        }

        // ���� Shift Ű�� ������ �� �޸��� ���·� ��ȯ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // �޸��� ���·� ����
            isRun = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // �޸��� ���� ����
            isRun = false;
        }

        // �޸��� ���¿� ���� �ִϸ��̼� ó��
        if (!isRun)
        {
            // �ȱ� ������ �� XInput�� YInput�� �Է� ���� �״�� ����
            animator.SetFloat("XInput", X);
            animator.SetFloat("YInput", Y);
        }
        else
        {
            // �޸��� ������ ���� ���� Ʈ���� ���� 2�� ����
            animator.SetFloat("XInput", X * 2f);
            animator.SetFloat("YInput", Y * 2f);
        }

        // ���콺 ���� ��ư�� Ŭ������ ��, ���� Ʈ���Ű� �����Ǿ� ������ �ش� Ʈ���� ����
        if (Input.GetMouseButtonDown(0) && currentTrigger != null && !isActionPlay)
        {
            // �ִϸ��̼��� ��� ���� �ƴϸ� Ʈ���� ����
            if (!isActionPlay)
            {
                // ���� ��ġ ����
                fixedPosition = transform.position;

                animator.SetTrigger(currentTrigger); // Ʈ���� �ִϸ��̼� ����
                isActionPlay = true; // �ִϸ��̼� ��� ������ ����
            }
        }
    }

    void CheckInput()
    {
        // ���� 1 Ű�� ������ �� Ʈ���Ÿ� "Axe"�� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTrigger = "Axe";
        }
        // ���� 2 Ű�� ������ �� Ʈ���Ÿ� "Pick"�� ����
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTrigger = "Pick";
        }
        // ���� 3 Ű�� ������ �� Ʈ���Ÿ� "Water"�� ����
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTrigger = "Water";
        }
        // ���� 4 Ű�� ������ �� Ʈ���Ÿ� "Slice"�� ����
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentTrigger = "Slice";
        }
    }

    // �ִϸ��̼��� ���� �� ȣ��� �޼���
    public void OnAnimationEnd()
    {
        isActionPlay = false; // �ִϸ��̼��� ������ �����Ӱ� �Է��� �ٽ� ���
    }
}