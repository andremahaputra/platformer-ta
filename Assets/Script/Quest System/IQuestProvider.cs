using System.Collections.Generic;

public interface IQuestProvider
{
    List<Quest> GetQuest();
    void TakeQuest(Quest quest);
}