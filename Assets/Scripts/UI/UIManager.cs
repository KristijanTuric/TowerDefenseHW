using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text interactionText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDoorMessage(string message)
    {
        interactionText.text = message;
        interactionText.enabled = true;
    }

    public void HideDoorMessage()
    {
        interactionText.enabled = false;
    }
}
