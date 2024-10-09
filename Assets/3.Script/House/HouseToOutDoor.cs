using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseToOutDoor : MonoBehaviour
{
    // 플레이어가 밟아야 하는 타일 태그
    public string targetTag = "TriggerTile";

    // 로드할 씬의 이름을 Inspector에서 설정
    public string nextSceneName;

    // 충돌이 발생했을 때 호출되는 메서드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트의 태그가 지정된 태그와 일치하는지 확인
        if (collision.CompareTag(targetTag))
        {
            // 인게임 씬으로 이동 (씬 이름은 프로젝트에 맞게 변경 필요)
            SceneManager.LoadScene("InGame");
        }
    }
}
