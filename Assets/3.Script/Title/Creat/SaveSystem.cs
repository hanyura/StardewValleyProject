using UnityEngine;
using System.IO;

// ĳ���� �����͸� ������ Ŭ���� ���� (Serializable �Ӽ��� ���� JSON ��ȯ ����)
[System.Serializable]
public class CharacterData
{
    public string playerName; // �÷��̾� �̸�
    public string farmName;   // ���� �̸�
}

// JSON ���Ϸ� �����͸� �����ϰ� �ҷ����� Ŭ����
public static class SaveSystem
{
    // �����Ͱ� ����� ���� ��� ����
    private static string savePath = Application.persistentDataPath + "/characterData.json";

    // ĳ���� �����͸� JSON �������� �����ϴ� �Լ�
    public static void SaveData(CharacterData data)
    {
        // CharacterData ��ü�� JSON ���ڿ��� ��ȯ
        string json = JsonUtility.ToJson(data);
        // ��ȯ�� JSON ���ڿ��� ���Ͽ� ����
        File.WriteAllText(savePath, json);
    }

    // ����� JSON ���Ͽ��� ĳ���� �����͸� �ҷ����� �Լ�
    public static CharacterData LoadData()
    {
        // ������ �����ϴ��� Ȯ��
        if (File.Exists(savePath))
        {
            // ���� ������ �о JSON ���ڿ��� ��ȯ
            string json = File.ReadAllText(savePath);
            // JSON ���ڿ��� CharacterData ��ü�� ��ȯ�Ͽ� ��ȯ
            return JsonUtility.FromJson<CharacterData>(json);
        }
        // ������ ������ null ��ȯ
        return null;
    }
}
