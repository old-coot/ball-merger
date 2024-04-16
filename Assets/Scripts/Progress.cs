using UnityEngine;

public class Progress : MonoBehaviour
{
    public int Level;
    public int Coins;
    public Color BackgroundColor;
    public bool IsMusicOn;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    public void SetLevel(int level)
    {
        Level = level;
        Save();
    }

    public void AddCoins(int value)
    {
        Coins += value;
        Save();
    }
    [ContextMenu("DeleteFile")]
    public void DeleteFile()
    {
        SaveSystem.DeleteFile();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveSystem.Save(this);
    }
    [ContextMenu("Load")]
    public void Load()
    {
        ProgressGameData progressData = SaveSystem.Load();

        if (progressData != null)
        {
            Coins = progressData.Coins;
            Level = progressData.Level;
            Color color = new Color();
            color.r = progressData.BackgroundColor[0];
            color.g = progressData.BackgroundColor[1];
            color.b = progressData.BackgroundColor[2];
            BackgroundColor = color;
            IsMusicOn = progressData.IsMusicOn;
        }
        else
        {
            Coins = 0;
            Level = 1;
            BackgroundColor = Color.blue * 0.5f;
            IsMusicOn = true;
        }
    }

}
