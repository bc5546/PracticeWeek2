using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if (QuestManager.instance == null)
            {
                QuestManager.instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject questManager = new GameObject();
                    questManager.AddComponent<QuestManager>();
                    QuestManager.instance=questManager.GetComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if (QuestManager.instance == null) { 
            QuestManager.instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    public List<QuestDataSO> quests;

    private void Start()
    {
        int count = 1;
        foreach (var quest in quests) {
            Debug.Log($"Quest{count} - {quest.name} (�ּ� ���� {quest.QuestRequiredLevel})");
            if (quest.GetType() == typeof(EncounterQuestDataSO))
            {
                EncounterQuestDataSO temp=quest as EncounterQuestDataSO;
                Debug.Log($"{temp.targetNPCName}�� ��ȭ�ϱ�");
            }
            else if (quest.GetType() == typeof(MonsterQuestDataSO))
            {
                MonsterQuestDataSO temp = quest as MonsterQuestDataSO;
                Debug.Log($"{temp.targetMonsterName}�� {temp.targetCount}���� ����");
            }
            count++;
        }
    }
}
