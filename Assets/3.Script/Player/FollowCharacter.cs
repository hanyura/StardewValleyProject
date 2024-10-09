using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Transform character; // 캐릭터의 Transform
    public Vector3 offset; // 텍스트의 위치 오프셋

    void Update()
    {
        if (character != null)
        {
            // 캐릭터의 위치에 오프셋을 더해 텍스트 위치를 갱신합니다.
            transform.position = character.position + offset;
        }
    }
}
