using UnityEngine;
using UnityEngine.UI;

public class MessagePresenter : MonoBehaviour
{
    [SerializeField] MessageDescriptionPanel descriptionPanel;

    [SerializeField] Text theme, whom;

    int index;

    [SerializeField] string description;

    public void GetMessageData(Message messageData)
    {
        theme.text = messageData.theme;
        whom.text = "From whom : " + messageData.whom;
        description = messageData.description;

        index = messageData.index;
    }


    public void GetDescriptionPanel(MessageDescriptionPanel panel) => descriptionPanel = panel;

    public void OpenMessageDescription() => 
        descriptionPanel.HandleMessageData(theme.text, description, index);
}