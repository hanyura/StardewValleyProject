using UnityEngine;
using UnityEngine.UI;

// �ΰ��� UI�� �����ϴ� Ŭ����
public class LoadJson : MonoBehaviour
{
    // �÷��̾� �̸��� ���� �̸��� ǥ���� �ؽ�Ʈ UI
    public Text playerNameText;
    public Text farmNameText;

    // �ΰ��� ���� ���۵� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        // SaveSystem�� ����Ͽ� ����� ĳ���� �����͸� �ҷ���
        CharacterData characterData = SaveSystem.LoadData();

        // ����� �����Ͱ� ���� ��� UI�� �ش� ������ ǥ��
        if (characterData != null)
        {
            playerNameText.text = "Player Name: " + characterData.playerName;
            farmNameText.text = "Farm Name: " + characterData.farmName;
        }
        // �����Ͱ� ���� ��� �⺻ �޽��� ǥ��
        else
        {
            playerNameText.text = "No Data Found";
            farmNameText.text = "No Data Found";
        }
    }
}
