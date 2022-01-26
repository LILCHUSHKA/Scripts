using UnityEngine;

public class FinalyName : MonoBehaviour
{
    [SerializeField] string gameName;

    public void GetGameName(string value) => gameName = value;

    public string GetName()
    {
        return gameName;
    }
}