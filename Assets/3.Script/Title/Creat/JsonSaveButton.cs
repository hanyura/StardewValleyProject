using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JsonSaveButton : MonoBehaviour
{
    public Button CreatButton;               // 생성 버튼
    public InputField characterNameInput;    // 캐릭터 이름 입력 필드 (Inspector에서 연결)
    public InputField farmNameInput;         // 농장 이름 입력 필드 (Inspector에서 연결)
    private string saveDirectory;

    private void Start()
    {
        // 버튼 클릭 시 Save 메서드 호출
        CreatButton.onClick.AddListener(Save);

        // 저장 디렉토리 설정 (애플리케이션의 데이터 경로에 저장)
        saveDirectory = Application.persistentDataPath + "/Saves/";

        // 저장 디렉토리가 존재하지 않으면 생성
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    void Save()
    {
        // 캐릭터 데이터 생성
        Data characterData = new Data();
        characterData.playerNewName = characterNameInput.text; // 입력 필드에서 캐릭터 이름 가져오기
        characterData.FarmNewName = farmNameInput.text;           // 입력 필드에서 농장 이름 가져오기

        // 캐릭터 데이터를 저장
        SaveCharacter(characterData);
    }

    public void SaveCharacter(Data characterData)
    {
        // 캐릭터 파일 번호를 결정
        int characterNumber = GetNextCharacterNumber();

        // 파일 경로 설정
        string filePath = saveDirectory + "character" + characterNumber + ".json";

        // JSON으로 직렬화
        string json = JsonUtility.ToJson(characterData);

        // 파일에 JSON 저장
        File.WriteAllText(filePath, json);

        Debug.Log("캐릭터가 저장되었습니다: " + filePath);
    }

    private int GetNextCharacterNumber()
    {
        // 저장된 캐릭터 파일 수를 기반으로 다음 번호 결정
        int count = 1;
        while (File.Exists(saveDirectory + "character" + count + ".json"))
        {
            count++;
        }
        return count;
    }
}
