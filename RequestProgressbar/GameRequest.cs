using UnityEngine;

public class GameRequest : RequestProgressbar
{
    [SerializeField] NewGameData newGame;
    [SerializeField] Engine gameEngine;

    protected override void SetStadyNames() => SetRequestName(newGame.finalyName.GetName());

    public override void GetRequest(NewGameData newGameData, Office office)
    {
        base.GetRequest(newGameData, office);

        newGame = newGameData;
        gameEngine = office.usedEngine;
    }

    protected override void ProgressbarFinished()
    {
        base.ProgressbarFinished();

        busyOffice.AddReleasedGame();

        StartScoreCalculation(newGame.scoreCalculation);
    }

    public void StartScoreCalculation(NewGameScoreCalculator gameScoreCalculation) =>
        gameScoreCalculation.GetNewGameData(newGame, gameEngine);
}