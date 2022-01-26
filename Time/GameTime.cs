using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    [SerializeField] Text dayText, weekText, monthText, yearText;

    [SerializeField] static int day = 6, week = 1, month = 11, year = 1980;

    [SerializeField] float dayLength;

    private void Start() => StartCoroutine(TimeTimer());

    void ChangeDate()
    {
        day++;

        if (day == 8)
        {
            day = 1;

            week++;
            weekText.text = "W : " + week.ToString();
        }

        if (week == 5)
        {
            week = 1;
            weekText.text = "W : " + week.ToString();

            month++;
            monthText.text = "M : " + month.ToString();
        }

        if (month == 13)
        {
            month = 1;
            monthText.text = "M : " + month.ToString();

            year++;
            yearText.text = "Y : " + year.ToString();
        }

        dayText.text = "D : " + day.ToString();

        GlobalEvents.OnDateChange.Invoke(day, week, month, year);
    }

    public static string GetDate()
    {
        return day + "." + month + "." + year;
    }

    IEnumerator TimeTimer()
    {
        while (year != 3000)
        {
            yield return new WaitForSecondsRealtime(dayLength);
            ChangeDate();
        }
    }
}