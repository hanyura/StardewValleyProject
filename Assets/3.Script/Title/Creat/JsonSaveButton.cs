using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 캐릭터 생성 UI를 관리하는 클래스
public class JsonSaveButton : MonoBehaviour
{
    // 인풋 필드 (플레이어 이름과 농장 이름 입력 받기 위한 UI 요소)
    public InputField playerNameInput;
    public InputField farmNameInput;

    // OK 버튼이 눌렸을 때 호출되는 함수
    public void OnOkButtonPressed()
    {
        // 인풋 필드에서 입력된 이름과 농장 이름을 가져옴
        string playerName = playerNameInput.text;
        string farmName = farmNameInput.text;

        // CharacterData 객체를 생성하고 입력된 데이터로 초기화
        CharacterData characterData = new CharacterData
        {
            playerName = playerName,
            farmName = farmName
        };

        // SaveSystem을 사용하여 JSON 파일로 데이터 저장
        SaveSystem.SaveData(characterData);

        // 인게임 씬으로 이동 (씬 이름은 프로젝트에 맞게 변경 필요)
        SceneManager.LoadScene("House");
    }
}
