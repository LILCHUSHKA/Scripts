public class EngineUpdatingProgressbar : RequestProgressbar
{
    public void GetUpdatingData(Office office)
    {
        busyOffice = office;
        busyOffice.MakeBusy(true);
    }

    protected override void ProgressbarFinished()
    {
        base.ProgressbarFinished();
        busyOffice.SetUsedEngine(Engine.thisEngine);
    }
}