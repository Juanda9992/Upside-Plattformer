using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private FlexibleColorPicker flexibleColorPicker;
    [SerializeField] private Player_Color player_Color;


    void Start()
    {
        flexibleColorPicker.onColorChange.AddListener(ChangePlayerColor); 
        if(CheckIfColorExits())
        {
            flexibleColorPicker.SetColor(LoadColor());
        }
    }

    private void ChangePlayerColor(Color color)
    {
        player_Color.ChangeColor(color);
        SaveColor(color);
    }

    private void SaveColor(Color color)
    {
        PlayerPrefs.SetFloat("R",color.r);
        PlayerPrefs.SetFloat("G",color.g);
        PlayerPrefs.SetFloat("B",color.b);
        PlayerPrefs.Save();
    }

    private bool CheckIfColorExits()
    {
        if(PlayerPrefs.GetFloat("R") == 0)
        {
            return false;
        }

        return true;
    }

    private Color LoadColor()
    {
        Color loadedColor = new Color();

        loadedColor.r = PlayerPrefs.GetFloat("R");
        loadedColor.g = PlayerPrefs.GetFloat("G");
        loadedColor.b = PlayerPrefs.GetFloat("B");
        loadedColor.a = 1;
        return loadedColor;
    }

}
