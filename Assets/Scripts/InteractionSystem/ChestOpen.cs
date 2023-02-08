using UnityEngine;

public class ChestOpen: Interactable {

    public GameObject pivot; 
    public Animation anim;
    private bool played;

    private void Start() 
    {
        anim = pivot.GetComponent<Animation>();
    }

    

    public override string GetDescription() {
        return "Press [E] to open the chest.";
        
    }

    public override void Interact() {
        
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        if(!played)
        {
            pivot.GetComponent<Animation>().PlayQueued("chest");
            played = true;
        }
        
    }
}
