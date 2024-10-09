using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectSpawne : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 배치할 오브젝트의 프리팹 배열
    public Tilemap tilemap; // 타일맵 참조

    public int xMin, xMax, yMin, yMax; // 선택할 구역의 좌표 범위
    public int minObjects = 1; // 최소 배치할 오브젝트 수
    public int maxObjects = 10; // 최대 배치할 오브젝트 수

    void Start()
    {
        // 배치할 오브젝트 수를 랜덤으로 결정
        int objectCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < objectCount; i++)
        {
            // 랜덤으로 타일맵 내의 위치를 선택
            int x = Random.Range(xMin, xMax + 1);
            int y = Random.Range(yMin, yMax + 1);
            Vector3Int cellPosition = new Vector3Int(x, y, 0);
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition);

            // 랜덤한 오브젝트 선택
            GameObject prefabToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // 오브젝트 생성
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);
        }
    }
}