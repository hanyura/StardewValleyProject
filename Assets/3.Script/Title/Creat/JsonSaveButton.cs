using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JsonSaveButton : MonoBehaviour
{
    public Button CreatButton;               // ���� ��ư
    public InputField characterNameInput;    // ĳ���� �̸� �Է� �ʵ� (Inspector���� ����)
    public InputField farmNameInput;         // ���� �̸� �Է� �ʵ� (Inspector���� ����)
    private string saveDirectory;

    private void Start()
    {
        // ��ư Ŭ�� �� Save �޼��� ȣ��
        CreatButton.onClick.AddListener(Save);

        // ���� ���丮 ���� (���ø����̼��� ������ ��ο� ����)
        saveDirectory = Application.persistentDataPath + "/Saves/";

        // ���� ���丮�� �������� ������ ����
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    void Save()
    {
        // ĳ���� ������ ����
        Data characterData = new Data();
        characterData.playerNewName = characterNameInput.text; // �Է� �ʵ忡�� ĳ���� �̸� ��������
        characterData.FarmNewName = farmNameInput.text;           // �Է� �ʵ忡�� ���� �̸� ��������

        // ĳ���� �����͸� ����
        SaveCharacter(characterData);
    }

    public void SaveCharacter(Data characterData)
    {
        // ĳ���� ���� ��ȣ�� ����
        int characterNumber = GetNextCharacterNumber();

        // ���� ��� ����
        string filePath = saveDirectory + "character" + characterNumber + ".json";

        // JSON���� ����ȭ
        string json = JsonUtility.ToJson(characterData);

        // ���Ͽ� JSON ����
        File.WriteAllText(filePath, json);

        Debug.Log("ĳ���Ͱ� ����Ǿ����ϴ�: " + filePath);
    }

    private int GetNextCharacterNumber()
    {
        // ����� ĳ���� ���� ���� ������� ���� ��ȣ ����
        int count = 1;
        while (File.Exists(saveDirectory + "character" + count + ".json"))
        {
            count++;
        }
        return count;
    }
}
