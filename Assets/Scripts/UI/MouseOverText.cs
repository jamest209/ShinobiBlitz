using UnityEngine;

public class MouseOverText : MonoBehaviour {

    public GameObject panel_text;

	public void DisplayText()
    {
        panel_text.SetActive(true);
    }

    public void TurnOffText()
    {
        panel_text.SetActive(false);
    }
}
