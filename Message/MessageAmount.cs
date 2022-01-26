using UnityEngine;
using UnityEngine.UI;

public class MessageAmount : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip messageAudioClip;

    [SerializeField] Text messagesCountText;

    private void Start() => 
        GlobalEvents.OnMessageAdd.AddListener(messageCount => HandleMessageCount(messageCount));

    void HandleMessageCount(int messagesCount)
    {
        audioSource.PlayOneShot(messageAudioClip);
        messagesCountText.text = messagesCount.ToString();
    }
}