using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] CloudPrefabs; // 3가지 구름 프리팹을 배열로 저장
    public int PoolingCount = 30; // 풀링할 구름의 개수

    public float MinXStartPos = 20f; // 처음 구름을 배치할 X축 최소값
    public float MaxXStartPos = -10f; // 처음 구름을 배치할 X축 최대값
    public float MinYStartPos = 0f; // 처음 구름을 배치할 Y축 최소값
    public float MaxYStartPos = 10f; // 처음 구름을 배치할 Y축 최대값

    public float MinYSpawn = 0f; // 오른쪽 화면 바깥에서 생성할 Y축 최소값
    public float MaxYSpawn = 10f; // 오른쪽 화면 바깥에서 생성할 Y축 최대값
    public float SpawnXPos = 10f; // 구름이 화면 밖에서 생성될 X축 위치 (오른쪽)
    public float DestroyXPos = -30f; // 구름이 사라질 X축 위치 (왼쪽)

    public float MinSpeed = 0.5f; // 구름이 이동하는 최소 속도
    public float MaxSpeed = 0.5f; // 구름이 이동하는 최대 속도

    private GameObject[] Clouds; // 구름을 저장할 배열
    private float[] CloudSpeeds; // 각 구름의 이동 속도를 저장하는 배열
    private Vector2 OffScreenPos = new Vector2(20f, -25f); // 처음 구름을 숨길 위치

    private int currentCloudIndex = 0; // 현재 사용할 구름 인덱스

    // Start is called before the first frame update
    void Start()
    {
        // 구름 배열 초기화
        Clouds = new GameObject[PoolingCount];
        CloudSpeeds = new float[PoolingCount];

        // 초기 구름 배치
        for (int i = 0; i < PoolingCount; i++)
        {
            // 랜덤한 구름 프리팹 선택
            int randomIndex = Random.Range(0, CloudPrefabs.Length);

            // 구름 인스턴스 생성 후 임시로 화면 밖에 배치
            Clouds[i] = Instantiate(CloudPrefabs[randomIndex], OffScreenPos, Quaternion.identity);

            // 초기 위치는 지정된 X, Y 범위 내에서 랜덤하게 배치
            float randomX = Random.Range(MinXStartPos, MaxXStartPos);
            float randomY = Random.Range(MinYStartPos, MaxYStartPos);
            Clouds[i].transform.position = new Vector2(randomX, randomY);

            // 구름의 이동 속도를 랜덤하게 설정
            CloudSpeeds[i] = Random.Range(MinSpeed, MaxSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 각 구름을 업데이트
        for (int i = 0; i < PoolingCount; i++)
        {
            // 구름을 왼쪽으로 이동
            Clouds[i].transform.Translate(Vector2.left * CloudSpeeds[i] * Time.deltaTime);

            // 구름이 화면 왼쪽 끝을 넘어가면
            if (Clouds[i].transform.position.x < DestroyXPos)
            {
                // 구름을 비활성화 후 다시 오른쪽에서 재활용
                RecycleCloud(i);
            }
        }
    }

    // 구름을 재활용하는 함수
    void RecycleCloud(int index)
    {
        // 랜덤한 구름 프리팹으로 교체할 수도 있음
        int randomIndex = Random.Range(0, CloudPrefabs.Length);
        Clouds[index].SetActive(false); // 비활성화했다가
        Clouds[index] = Instantiate(CloudPrefabs[randomIndex], OffScreenPos, Quaternion.identity); // 다시 활성화

        // 새로 나타날 Y축 위치를 랜덤하게 설정
        float randomY = Random.Range(MinYSpawn, MaxYSpawn);
        Clouds[index].transform.position = new Vector2(SpawnXPos, randomY);

        // 구름의 이동 속도도 다시 랜덤하게 설정
        CloudSpeeds[index] = Random.Range(MinSpeed, MaxSpeed);

        // 구름을 다시 활성화
        Clouds[index].SetActive(true);
    }
}
