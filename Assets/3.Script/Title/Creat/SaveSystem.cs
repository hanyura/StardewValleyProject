using UnityEngine;
using System.IO;

// 캐릭터 데이터를 저장할 클래스 정의 (Serializable 속성을 통해 JSON 변환 가능)
[System.Serializable]
public class CharacterData
{
    public string playerName; // 플레이어 이름
    public string farmName;   // 농장 이름
}

// JSON 파일로 데이터를 저장하고 불러오는 클래스
public static class SaveSystem
{
    // 데이터가 저장될 파일 경로 설정
    private static string savePath = Application.persistentDataPath + "/characterData.json";

    // 캐릭터 데이터를 JSON 형식으로 저장하는 함수
    public static void SaveData(CharacterData data)
    {
        // CharacterData 객체를 JSON 문자열로 변환
        string json = JsonUtility.ToJson(data);
        // 변환된 JSON 문자열을 파일에 저장
        File.WriteAllText(savePath, json);
    }

    // 저장된 JSON 파일에서 캐릭터 데이터를 불러오는 함수
    public static CharacterData LoadData()
    {
        // 파일이 존재하는지 확인
        if (File.Exists(savePath))
        {
            // 파일 내용을 읽어서 JSON 문자열로 변환
            string json = File.ReadAllText(savePath);
            // JSON 문자열을 CharacterData 객체로 변환하여 반환
            return JsonUtility.FromJson<CharacterData>(json);
        }
        // 파일이 없으면 null 반환
        return null;
    }
}
