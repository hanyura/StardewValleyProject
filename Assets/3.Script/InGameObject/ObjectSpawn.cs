using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectSpawne : MonoBehaviour
{
    public GameObject[] objectPrefabs; // ��ġ�� ������Ʈ�� ������ �迭
    public Tilemap tilemap; // Ÿ�ϸ� ����

    public int xMin, xMax, yMin, yMax; // ������ ������ ��ǥ ����
    public int minObjects = 1; // �ּ� ��ġ�� ������Ʈ ��
    public int maxObjects = 10; // �ִ� ��ġ�� ������Ʈ ��

    void Start()
    {
        // ��ġ�� ������Ʈ ���� �������� ����
        int objectCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < objectCount; i++)
        {
            // �������� Ÿ�ϸ� ���� ��ġ�� ����
            int x = Random.Range(xMin, xMax + 1);
            int y = Random.Range(yMin, yMax + 1);
            Vector3Int cellPosition = new Vector3Int(x, y, 0);
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition);

            // ������ ������Ʈ ����
            GameObject prefabToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // ������Ʈ ����
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);
        }
    }
}