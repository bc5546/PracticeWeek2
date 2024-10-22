using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject arrowPrefab;
    private List<GameObject> monsterPool = new List<GameObject>();
    private List<GameObject> arrowPool = new List<GameObject>();
    private Dictionary<string, List<GameObject>> pools;
    public int monsterPoolSize = 50;
    public int arrowPoolSize = 300;

    void Start()
    {
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.

        for (int i = 0; i < monsterPoolSize; i++) 
        {
            GameObject gameObject = Instantiate(monsterPrefab);
            monsterPool.Add(gameObject);
        }

        for (int i = 0;i < arrowPoolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab);    
            arrowPool.Add(arrow);
        }

        pools.Add("Monster", monsterPool);
        pools.Add("Arrow", arrowPool);
        
    }

    public GameObject GetMonster()
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
        GameObject obj = pools["Monster"][0];
        pools["Monster"].Add(obj);
        obj.SetActive(true);
        return obj;
    }

    public GameObject GetArrow()
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
        GameObject obj = pools["Arrow"][0];
        pools["Arrow"].Add(obj);
        obj.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj.SetActive(false);
    }
}