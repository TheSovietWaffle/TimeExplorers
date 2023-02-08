using UnityEngine;

public class DestroyObject: Interactable {

    public GameObject _object; 
    private bool isDestroyed;

    public override string GetDescription() {
        return "Press [E] to pick up the artefact.";
        
    }

    public override void Interact() {
        
        DestroyObj();
    }

    public void DestroyObj()
    {
        if(!isDestroyed)
        {
            Destroy(_object);
            isDestroyed = true;
        }
        
    }
}
