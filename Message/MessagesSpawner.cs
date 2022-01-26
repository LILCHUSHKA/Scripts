using UnityEngine;
using System.Collections;

public class MessagesSpawner : MonoBehaviour
{
    [SerializeField] MessageDescriptionPanel descriptionPanel;

    [SerializeField] MessagePresenter messagePresenter;

    [SerializeField] Transform bag;

    [SerializeField] float spawnDelay;

    private void OnEnable() => SpawnMessages();

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    public void SpawnMessages()
    {
        ClearBag();
        StartCoroutine(SpawnDelay());
    }

    //Узнать подробности на счет производительности такого способа
    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < MessageList.messages.Count; i++)
        {
            MessageList.messages[i].index = i;

            messagePresenter.GetMessageData(MessageList.messages[i]);
            messagePresenter.GetDescriptionPanel(descriptionPanel);
            Instantiate(messagePresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}