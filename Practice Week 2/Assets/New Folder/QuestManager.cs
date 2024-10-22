using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
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

    // [구현사항 3] 인스턴스 검사 로직
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
            Debug.Log($"Quest{count} - {quest.name} (최소 레벨 {quest.QuestRequiredLevel})");
            if (quest.GetType() == typeof(EncounterQuestDataSO))
            {
                EncounterQuestDataSO temp=quest as EncounterQuestDataSO;
                Debug.Log($"{temp.targetNPCName}과 대화하기");
            }
            else if (quest.GetType() == typeof(MonsterQuestDataSO))
            {
                MonsterQuestDataSO temp = quest as MonsterQuestDataSO;
                Debug.Log($"{temp.targetMonsterName}를 {temp.targetCount}마리 소탕");
            }
            count++;
        }
    }
}
