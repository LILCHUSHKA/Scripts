using UnityEngine;

public class NewGameData : MonoBehaviour
{
    [SerializeField] RequestCity requestCity;
    [SerializeField] GameRequest GRP;

    public NewGameScoreCalculator scoreCalculation;
    public FinalyGenre finalyGenre;
    public FinalyPlatform finalyPlatform;
    public FinalyTheme finalyTheme;
    public FinalyPrice finalyPrice;
    public FinalyName finalyName;

    [SerializeField] GameObject requestsPanel;
    [SerializeField] GameObject gameRequestPanel;

    public Transform GRPBag;

    public void CreateNewGame()
    {
        if (GameIsReady())
        {
            GRP.GetRequest(this, requestCity.office);
            GRP.GetRequestTime(Engine.GetDevelopmentTime() + (finalyPrice.GetGamePrice() / 100000) + 
                (requestCity.office.Employees() / 10));

            requestsPanel.SetActive(true);
            gameRequestPanel.SetActive(false);

            Instantiate(GRP, GRPBag);
        }
    }

    bool GameIsReady()
    {
        bool isReady = false;

        if (finalyGenre != null) isReady = true;
        else isReady = false;
        if (finalyPlatform != null) isReady = true;
        else isReady = false;
        if (finalyTheme != null) isReady = true;
        else isReady = false;
        if (finalyName.GetName().Length > 1) isReady = true;
        else isReady = false;

        return isReady;
    }
}