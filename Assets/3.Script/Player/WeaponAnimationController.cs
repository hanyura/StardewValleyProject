using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationController : MonoBehaviour
{
    // ���� �ִϸ��̼� ������ �迭 (����, ���, ���Ѹ���, ȣ�� ��)
    public GameObject[] weaponPrefabs;

    // ���� ���õ� ������ Ʈ���� �̸��� �����ϴ� ����
    private string currentWeaponTrigger;

    // �ִϸ��̼��� ��� ������ Ȯ���ϴ� ����
    private bool isAnimationPlaying;

    // �÷��̾ ���� ������ ��ġ�� �����ϴ� ����
    private Vector3 fixedPosition;

    // �÷��̾��� Animator ������Ʈ�� �����ϴ� ����
    private Animator playerAnimator;

    // ��ũ��Ʈ�� ó�� ���۵� �� ȣ��Ǵ� �޼��� (�ʱ� ����)
    private void Start()
    {
        // Animator ������Ʈ�� �����ͼ� ����
        playerAnimator = GetComponent<Animator>();

        // �ʱ⿡�� �ִϸ��̼��� ��� ���� �ƴ�
        isAnimationPlaying = false;
    }

    // ���� ���� Ʈ���Ÿ� �����ϴ� �޼���
    public void SetWeaponTrigger(string triggerName)
    {
        currentWeaponTrigger = triggerName; // ���� ���õ� Ʈ���Ÿ� ����
    }

    // ���� �ִϸ��̼��� �����ϴ� �޼���
    public void PlayWeaponAnimation()
    {
        // Ʈ���Ű� �����Ǿ� ���� �ʰų�, �̹� �ִϸ��̼��� ��� ���̸� �������� ����
        if (currentWeaponTrigger == null || isAnimationPlaying)
            return;

        // �÷��̾��� ������ �̵� ������ ������
        float lastMoveX = playerAnimator.GetFloat("LastMoveX");
        float lastMoveY = playerAnimator.GetFloat("LastMoveY");

        // ���� �ִϸ��̼��� �÷��̾ �ٶ󺸴� ���⿡ ���� ����
        Vector3 weaponPosition = transform.position + new Vector3(lastMoveX, lastMoveY, 0);

        // ���� ���õ� ���� �ִϸ��̼��� ���� (�ε����� ���� ����)
        GameObject weapon = Instantiate(weaponPrefabs[GetWeaponIndex()], weaponPosition, Quaternion.identity);

        // ���� �ִϸ��̼��� ������ ���� (����, ������, ��, �Ʒ�)
        if (lastMoveX < 0)
        {
            weapon.transform.localScale = new Vector3(-1, 1, 1); // ���� ����
        }
        else if (lastMoveX > 0)
        {
            weapon.transform.localScale = new Vector3(1, 1, 1); // ������ ����
        }
        else if (lastMoveY < 0)
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, 0); // �Ʒ��� ����
        }
        else if (lastMoveY > 0)
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, 180); // ���� ����
        }

        // ���� �ð��� ������ ���� �ִϸ��̼��� ����
        Destroy(weapon, 0.5f);

        // �ִϸ��̼��� ��� ������ ǥ��
        isAnimationPlaying = true;

        // �ִϸ��̼��� ������ ȣ��� �޼��� ���� (0.5�� ��)
        Invoke("EndAnimation", 0.5f);
    }

    // ���� ���õ� ���⿡ ���� �ε����� ��ȯ�ϴ� �޼���
    private int GetWeaponIndex()
    {
        switch (currentWeaponTrigger)
        {
            case "Axe":
                return 0; // ����
            case "Pick":
                return 1; // ���
            case "Water":
                return 2; // ���Ѹ���
            case "Slice":
                return 3; // ������
            case "Hoe":
                return 4; // **ȣ�� �߰�**
            default:
                return 0; // �⺻���� ������ ����
        }
    }

    // �ִϸ��̼��� ������ �� ȣ��Ǵ� �޼���
    private void EndAnimation()
    {
        isAnimationPlaying = false; // �ִϸ��̼��� �������� ǥ��
    }
}
