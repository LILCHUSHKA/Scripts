using UnityEngine;
using UnityEngine.UI;

public class NewGameRequestActivator : MonoBehaviour
{
    [SerializeField] Image newGameRequestImage, engineRequestImage, officeWindowButtonImage;
    [SerializeField] Sprite newSprite;

    [SerializeField] Button newGameRequestButton, engineRequestButton, officeWindowButton;

    bool gameRequestIsActive, engineRequestIsActive;

    private void Start()
    {
        GlobalEvents.OnPlayerBuyStudio.AddListener(text => UnlockEngineRequest());
        GlobalEvents.OnEngineUpdate.AddListener(UnlockNewGameRequest);
    }

    void UnlockNewGameRequest()
    {
        gameRequestIsActive = true;

        newGameRequestImage.sprite = newSprite;
        newGameRequestButton.enabled = true;

        officeWindowButtonImage.sprite = newSprite;
        officeWindowButton.enabled = true;

        CheckTimeToDelete();
    }

    void UnlockEngineRequest()
    {
        engineRequestIsActive = true;

        engineRequestImage.sprite = newSprite;
        engineRequestButton.enabled = true;

        CheckTimeToDelete();
    }

    void CheckTimeToDelete()
    {
        bool isTime = gameRequestIsActive && engineRequestIsActive;

        if (isTime)
        {
            RemoveListeners();
            Destroy(gameObject);
        }
    }

    void RemoveListeners()
    {
        GlobalEvents.OnPlayerBuyStudio.RemoveListener(text => UnlockEngineRequest());
        GlobalEvents.OnEngineUpdate.RemoveListener(UnlockNewGameRequest);
    }
}