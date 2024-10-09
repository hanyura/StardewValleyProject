using UnityEngine;
using UnityEngine.UI;

// 인게임 UI를 관리하는 클래스
public class LoadJson : MonoBehaviour
{
    // 플레이어 이름과 농장 이름을 표시할 텍스트 UI
    public Text playerNameText;
    public Text farmNameText;

    // 인게임 씬이 시작될 때 호출되는 함수
    void Start()
    {
        // SaveSystem을 사용하여 저장된 캐릭터 데이터를 불러옴
        CharacterData characterData = SaveSystem.LoadData();

        // 저장된 데이터가 있을 경우 UI에 해당 정보를 표시
        if (characterData != null)
        {
            playerNameText.text = "Player Name: " + characterData.playerName;
            farmNameText.text = "Farm Name: " + characterData.farmName;
        }
        // 데이터가 없을 경우 기본 메시지 표시
        else
        {
            playerNameText.text = "No Data Found";
            farmNameText.text = "No Data Found";
        }
    }
}
