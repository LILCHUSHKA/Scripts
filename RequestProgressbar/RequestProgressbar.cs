using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestProgressbar : MonoBehaviour
{
    [SerializeField] protected Office busyOffice;

    [SerializeField] Text stadyNameText, requestNameText;
    [SerializeField] protected Slider progressbar;

    [SerializeField] protected int stadyStepValue;

    [SerializeField] protected List<string> stadyNames;

    private void Start()
    {
        SetStadyNames();
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) => UpdateProgressbar());

        stadyStepValue += (int)Mathf.Sqrt(progressbar.maxValue);
    }

    public virtual void GetRequest(List<Technology> newTechnologies, Office office)
    {
        busyOffice = office;
        busyOffice.MakeBusy(true);

        WeeklyPayment.AddPaymentValue(busyOffice.WeeklyPayment());
    }

    public virtual void GetRequest(NewGameData newGameData, Office office)
    {
        busyOffice = office;
        busyOffice.MakeBusy(true);

        WeeklyPayment.AddPaymentValue(busyOffice.Salary());
    }

    protected virtual void SetStadyNames() { }

    protected void SetRequestName(string requestName) => requestNameText.text = requestName;

    public void GetRequestTime(int time) => progressbar.maxValue = time;

    protected virtual void ProgressbarFinished()
    {
        GlobalEvents.OnDateChange.RemoveListener((day, week, month, year) => UpdateProgressbar());

        busyOffice.MakeBusy(false);
        WeeklyPayment.DecreasePaymentValue(busyOffice.Salary());

        Destroy(gameObject);
    }

    void UpdateProgressbar()
    {
        progressbar.value++;

        if (progressbar.value == progressbar.maxValue) ProgressbarFinished();

        if (stadyNames.Count != 0)
        {
            stadyNameText.text = stadyNames[0];

            if (progressbar.value >= stadyStepValue)
            {
                stadyNames.RemoveAt(0);
                stadyStepValue += (int)Mathf.Sqrt(progressbar.maxValue);
            }
        }
    }
}