using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ĳ���� ���� UI�� �����ϴ� Ŭ����
public class JsonSaveButton : MonoBehaviour
{
    // ��ǲ �ʵ� (�÷��̾� �̸��� ���� �̸� �Է� �ޱ� ���� UI ���)
    public InputField playerNameInput;
    public InputField farmNameInput;

    // OK ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void OnOkButtonPressed()
    {
        // ��ǲ �ʵ忡�� �Էµ� �̸��� ���� �̸��� ������
        string playerName = playerNameInput.text;
        string farmName = farmNameInput.text;

        // CharacterData ��ü�� �����ϰ� �Էµ� �����ͷ� �ʱ�ȭ
        CharacterData characterData = new CharacterData
        {
            playerName = playerName,
            farmName = farmName
        };

        // SaveSystem�� ����Ͽ� JSON ���Ϸ� ������ ����
        SaveSystem.SaveData(characterData);

        // �ΰ��� ������ �̵� (�� �̸��� ������Ʈ�� �°� ���� �ʿ�)
        SceneManager.LoadScene("House");
    }
}
