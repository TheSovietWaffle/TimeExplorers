using UnityEngine;
using DG.Tweening;

public class LeverPullDoorOpen: Interactable {

    public GameObject pivot; 
    public GameObject door;
    public Animation anim;
    public Camera cam;
    private bool played;

    private void Start() 
    {
        anim = pivot.GetComponent<Animation>();
    }

    

    public override string GetDescription() {
        return "Press [E] to open the door.";
        
    }

    public override void Interact() {
        
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        if(!played)
        {
            pivot.GetComponent<Animation>().PlayQueued("LeverHandle");
            door.GetComponent<Animation>().PlayQueued("ExitDoor");
            cam.DOShakePosition(4.5f,0.1f);
            played = true;
        }
        
    }
}
