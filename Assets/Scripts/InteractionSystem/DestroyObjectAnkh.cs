using UnityEngine;

public class DestroyObject: Interactable {

    public GameObject _object; 
    public PlayerInfo pi;
    public string preferance;
    public GameObject cube;
    private bool isDestroyed;
    
    private void Start() {
            if(PlayerPrefs.GetString(preferance) == "Picked up")
            {
                Destroy(_object);
                cube.SetActive(false);
            }
    }

    public override string GetDescription() {
        return "Press [E] to pick up the artefact.";
        
    }

    public override void Interact() {
        
        DestroyObj();
    }

    public void DestroyObj()
    {
        if(!isDestroyed && PlayerPrefs.GetString(preferance)!= "Picked up")
        {
            PlayerPrefs.SetString(preferance, "Picked up");
            Destroy(_object);
            isDestroyed = true;
            cube.SetActive(false);
         
        }
        
    }
}
