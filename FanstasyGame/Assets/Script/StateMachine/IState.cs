using UnityEngine;

public interface IState 
{

    public void Entry();
    public void Exit();
    public void HandleInput();
    public void Update();
    public void PhysicsUpdate();


    public void OnTriggerEnter(Collider collider);
    public void OnAnimationEntryEvent();
    public void OnAnimationExitEvent();
    public void OnAnimationTrantionEvent();

}
