using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] CloudPrefabs; // 3���� ���� �������� �迭�� ����
    public int PoolingCount = 30; // Ǯ���� ������ ����

    public float MinXStartPos = 20f; // ó�� ������ ��ġ�� X�� �ּҰ�
    public float MaxXStartPos = -10f; // ó�� ������ ��ġ�� X�� �ִ밪
    public float MinYStartPos = 0f; // ó�� ������ ��ġ�� Y�� �ּҰ�
    public float MaxYStartPos = 10f; // ó�� ������ ��ġ�� Y�� �ִ밪

    public float MinYSpawn = 0f; // ������ ȭ�� �ٱ����� ������ Y�� �ּҰ�
    public float MaxYSpawn = 10f; // ������ ȭ�� �ٱ����� ������ Y�� �ִ밪
    public float SpawnXPos = 10f; // ������ ȭ�� �ۿ��� ������ X�� ��ġ (������)
    public float DestroyXPos = -30f; // ������ ����� X�� ��ġ (����)

    public float MinSpeed = 0.5f; // ������ �̵��ϴ� �ּ� �ӵ�
    public float MaxSpeed = 0.5f; // ������ �̵��ϴ� �ִ� �ӵ�

    private GameObject[] Clouds; // ������ ������ �迭
    private float[] CloudSpeeds; // �� ������ �̵� �ӵ��� �����ϴ� �迭
    private Vector2 OffScreenPos = new Vector2(20f, -25f); // ó�� ������ ���� ��ġ

    private int currentCloudIndex = 0; // ���� ����� ���� �ε���

    // Start is called before the first frame update
    void Start()
    {
        // ���� �迭 �ʱ�ȭ
        Clouds = new GameObject[PoolingCount];
        CloudSpeeds = new float[PoolingCount];

        // �ʱ� ���� ��ġ
        for (int i = 0; i < PoolingCount; i++)
        {
            // ������ ���� ������ ����
            int randomIndex = Random.Range(0, CloudPrefabs.Length);

            // ���� �ν��Ͻ� ���� �� �ӽ÷� ȭ�� �ۿ� ��ġ
            Clouds[i] = Instantiate(CloudPrefabs[randomIndex], OffScreenPos, Quaternion.identity);

            // �ʱ� ��ġ�� ������ X, Y ���� ������ �����ϰ� ��ġ
            float randomX = Random.Range(MinXStartPos, MaxXStartPos);
            float randomY = Random.Range(MinYStartPos, MaxYStartPos);
            Clouds[i].transform.position = new Vector2(randomX, randomY);

            // ������ �̵� �ӵ��� �����ϰ� ����
            CloudSpeeds[i] = Random.Range(MinSpeed, MaxSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �� ������ ������Ʈ
        for (int i = 0; i < PoolingCount; i++)
        {
            // ������ �������� �̵�
            Clouds[i].transform.Translate(Vector2.left * CloudSpeeds[i] * Time.deltaTime);

            // ������ ȭ�� ���� ���� �Ѿ��
            if (Clouds[i].transform.position.x < DestroyXPos)
            {
                // ������ ��Ȱ��ȭ �� �ٽ� �����ʿ��� ��Ȱ��
                RecycleCloud(i);
            }
        }
    }

    // ������ ��Ȱ���ϴ� �Լ�
    void RecycleCloud(int index)
    {
        // ������ ���� ���������� ��ü�� ���� ����
        int randomIndex = Random.Range(0, CloudPrefabs.Length);
        Clouds[index].SetActive(false); // ��Ȱ��ȭ�ߴٰ�
        Clouds[index] = Instantiate(CloudPrefabs[randomIndex], OffScreenPos, Quaternion.identity); // �ٽ� Ȱ��ȭ

        // ���� ��Ÿ�� Y�� ��ġ�� �����ϰ� ����
        float randomY = Random.Range(MinYSpawn, MaxYSpawn);
        Clouds[index].transform.position = new Vector2(SpawnXPos, randomY);

        // ������ �̵� �ӵ��� �ٽ� �����ϰ� ����
        CloudSpeeds[index] = Random.Range(MinSpeed, MaxSpeed);

        // ������ �ٽ� Ȱ��ȭ
        Clouds[index].SetActive(true);
    }
}
