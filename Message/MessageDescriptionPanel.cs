using UnityEngine;
using UnityEngine.UI;

public class MessageDescriptionPanel : MonoBehaviour
{
    [SerializeField] GameObject messageList;
    [SerializeField] Text themeText, descriptionText;

    int index;

    public void HandleMessageData(string theme, string description, int _index)
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);

        themeText.text = theme;
        descriptionText.text = description;

        index = _index;
    }

    public void DeleteMessage()
    {
        MessageList.messages.RemoveAt(index);

        messageList.SetActive(false);
        messageList.SetActive(true);

        gameObject.SetActive(false);

        GlobalEvents.OnMessageAdd.Invoke(MessageList.messages.Count);
    }

}