using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseToOutDoor : MonoBehaviour
{
    // �÷��̾ ��ƾ� �ϴ� Ÿ�� �±�
    public string targetTag = "TriggerTile";

    // �ε��� ���� �̸��� Inspector���� ����
    public string nextSceneName;

    // �浹�� �߻����� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� �±װ� ������ �±׿� ��ġ�ϴ��� Ȯ��
        if (collision.CompareTag(targetTag))
        {
            // �ΰ��� ������ �̵� (�� �̸��� ������Ʈ�� �°� ���� �ʿ�)
            SceneManager.LoadScene("InGame");
        }
    }
}
