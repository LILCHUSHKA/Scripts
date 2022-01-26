using UnityEngine;
using UnityEngine.UI;

public class Genre : MonoBehaviour
{
    public Sprite IconSprite { get; private set; }

    [SerializeField] FinalyGenre finalyGenre;

    [SerializeField] Image genreIcon, addGenreButton;

    public enum Genres
    {
        rpg,
        action,
        simulator,
        strategy,
        adventure,
        puzzle
    }
    public Genres genre;

    public void SetGenre()
    {
        addGenreButton.sprite = genreIcon.sprite;
        IconSprite = genreIcon.sprite;

        finalyGenre.GetGenre(this);
    }
}