
[System.Serializable]
public class ProgressGameData
{
    public int Coins;
    public int Level;
    public float[] BackgroundColor;
    public bool IsMusicOn;

    public ProgressGameData(Progress progress)
    {
        Coins = progress.Coins;
        Level = progress.Level;
        BackgroundColor = new float[3];
        BackgroundColor[0] = progress.BackgroundColor.r;
        BackgroundColor[1] = progress.BackgroundColor.g;
        BackgroundColor[2] = progress.BackgroundColor.b;
        IsMusicOn = progress.IsMusicOn;
    }
}