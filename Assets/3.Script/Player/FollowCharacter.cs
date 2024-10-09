using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform character; // ĳ������ Transform
    public Vector3 offset; // �ؽ�Ʈ�� ��ġ ������

    void Update()
    {
        if (character != null)
        {
            // ĳ������ ��ġ�� �������� ���� �ؽ�Ʈ ��ġ�� �����մϴ�.
            transform.position = character.position + offset;
        }
    }
}
