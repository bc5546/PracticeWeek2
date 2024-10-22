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
        // 미리 poolSize만큼 게임오브젝트를 생성한다.

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
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        GameObject obj = pools["Monster"][0];
        pools["Monster"].Add(obj);
        obj.SetActive(true);
        return obj;
    }

    public GameObject GetArrow()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        GameObject obj = pools["Arrow"][0];
        pools["Arrow"].Add(obj);
        obj.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
}