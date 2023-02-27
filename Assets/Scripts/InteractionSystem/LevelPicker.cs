using UnityEngine;

public class LightSwitch: Interactable {

    public GameObject sceneLoaderCanvas; // im using m_Light name since 'light' is already a variable used by unity
    public bool isOn;
    public Canvas pauMenu;

    private void Start() {
        
    }

    void UpdateMenu() {
        sceneLoaderCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        pauMenu.gameObject.SetActive(false);
        Cursor.visible = true;
    }

    public override string GetDescription() {
        return "Press [E] to select a level.";
        
    }

    public override void Interact() {
        
        UpdateMenu();
    }
}
