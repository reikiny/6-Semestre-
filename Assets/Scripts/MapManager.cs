using UnityEngine;
using UnityEngine.UI;
public class MapManager : MonoBehaviour
{
    public Button[] buttons;

    public bool[] active;
    public int number;

    private void Start()
    {
        active = new bool[buttons.Length];
        number = PlayerPrefs.GetInt("Level");
    }

    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i <= number - 1) active[i] = true;

            if (i > 0)
            {

                buttons[i].interactable = active[i - 1];

            }

        }
    }
}
