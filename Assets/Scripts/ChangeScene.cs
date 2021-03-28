using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int level;
    public TileManager tile;
    private void Start()
    {
        //PlayerPrefs.SetInt("Level", level);

    }
    private void Update()
    {
        if (tile && tile.endReached)
            Change("Map");
    }
    public void Change(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
        if (tile && tile.endReached)
        {
            tile.endReached = false;
            Save();

        }
    }

    void Save()
    {
        if (level > PlayerPrefs.GetInt("Level"))
            PlayerPrefs.SetInt("Level", level);

        //print(PlayerPrefs.GetInt("Level"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("Image1", 0);
        PlayerPrefs.SetInt("Image2", 0);
        PlayerPrefs.SetInt("Image3", 0);
        PlayerPrefs.SetInt("Image4", 0);
        PlayerPrefs.SetInt("Image5", 0);
        PlayerPrefs.SetInt("Image6", 0);
        PlayerPrefs.SetInt("Image7", 0);

    }
}
