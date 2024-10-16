using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // ��ġ�� ������Ʈ�� ������ �迭
    public Tilemap tilemap; // Ÿ�ϸ� ����

    public int xMin, xMax, yMin, yMax; // ������ ������ ��ǥ ����
    public int minObjects = 1; // �ּ� ��ġ�� ������Ʈ ��
    public int maxObjects = 10; // �ִ� ��ġ�� ������Ʈ ��

    private HashSet<Vector3Int> occupiedPositions = new HashSet<Vector3Int>(); // ��ġ�� Ÿ���� ��ġ�� ����

    void Start()
    {
        // ��ġ�� ������Ʈ ���� �������� ����
        int objectCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3Int cellPosition;

            // ���� ��ġ�� ã��, �̹� ��ġ�� ��ġ�� ����
            do
            {
                int x = Random.Range(xMin, xMax + 1);
                int y = Random.Range(yMin, yMax + 1);
                cellPosition = new Vector3Int(x, y, 0);
            }
            while (occupiedPositions.Contains(cellPosition)); // �̹� ��ġ�� ��ġ�� ����

            // ��ġ�� worldPosition���� ��ȯ
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition);

            // ������ ������Ʈ ����
            GameObject prefabToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // ������Ʈ ����
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);

            // ��ġ�� ��ġ ����
            occupiedPositions.Add(cellPosition); // ���ο� ��ġ�� ��ġ�� ����
        }
    }

    private void OnDrawGizmos()
    {
        if (tilemap == null) return;

        // Ÿ�ϸ��� �� ũ�� ��������
        Vector3 cellSize = tilemap.cellSize;

        // Ÿ�ϸ� ��ǥ�踦 ���� ��ǥ��� ��ȯ
        Vector3 bottomLeftWorld = tilemap.CellToWorld(new Vector3Int(xMin, yMin, 0));
        Vector3 topRightWorld = tilemap.CellToWorld(new Vector3Int(xMax, yMax, 0));

        // ���� ��ǥ�� �������� ������ �߽ɰ� ũ�⸦ ���
        Vector3 gizmoCenter = (bottomLeftWorld + topRightWorld) / 2f;
        Vector3 gizmoSize = new Vector3(Mathf.Abs(topRightWorld.x - bottomLeftWorld.x) + cellSize.x, Mathf.Abs(topRightWorld.y - bottomLeftWorld.y) + cellSize.y, 1f);

        // Gizmo�� ���� ������ �ð������� ǥ��
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(gizmoCenter, gizmoSize);
    }
}
