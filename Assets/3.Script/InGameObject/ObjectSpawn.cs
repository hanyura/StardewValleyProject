using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 배치할 오브젝트의 프리팹 배열
    public Tilemap tilemap; // 타일맵 참조

    public int xMin, xMax, yMin, yMax; // 선택할 구역의 좌표 범위
    public int minObjects = 1; // 최소 배치할 오브젝트 수
    public int maxObjects = 10; // 최대 배치할 오브젝트 수

    private HashSet<Vector3Int> occupiedPositions = new HashSet<Vector3Int>(); // 배치된 타일의 위치를 저장

    void Start()
    {
        // 배치할 오브젝트 수를 랜덤으로 결정
        int objectCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3Int cellPosition;

            // 랜덤 위치를 찾되, 이미 배치된 위치는 피함
            do
            {
                int x = Random.Range(xMin, xMax + 1);
                int y = Random.Range(yMin, yMax + 1);
                cellPosition = new Vector3Int(x, y, 0);
            }
            while (occupiedPositions.Contains(cellPosition)); // 이미 배치된 위치는 피함

            // 위치를 worldPosition으로 변환
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition);

            // 랜덤한 오브젝트 선택
            GameObject prefabToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // 오브젝트 생성
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);

            // 배치된 위치 저장
            occupiedPositions.Add(cellPosition); // 새로운 배치된 위치를 저장
        }
    }

    private void OnDrawGizmos()
    {
        if (tilemap == null) return;

        // 타일맵의 셀 크기 가져오기
        Vector3 cellSize = tilemap.cellSize;

        // 타일맵 좌표계를 월드 좌표계로 변환
        Vector3 bottomLeftWorld = tilemap.CellToWorld(new Vector3Int(xMin, yMin, 0));
        Vector3 topRightWorld = tilemap.CellToWorld(new Vector3Int(xMax, yMax, 0));

        // 월드 좌표를 기준으로 범위의 중심과 크기를 계산
        Vector3 gizmoCenter = (bottomLeftWorld + topRightWorld) / 2f;
        Vector3 gizmoSize = new Vector3(Mathf.Abs(topRightWorld.x - bottomLeftWorld.x) + cellSize.x, Mathf.Abs(topRightWorld.y - bottomLeftWorld.y) + cellSize.y, 1f);

        // Gizmo로 스폰 범위를 시각적으로 표시
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(gizmoCenter, gizmoSize);
    }
}
