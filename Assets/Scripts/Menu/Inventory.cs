using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

  
    private Animator _animator;
    private CanvasGroup _canvasGroup;
	public bool IsOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value); }
    }
	
    public void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
        //Allows the the UI start at the very center of the windows during game.
        //We are now able to change the position of the UI wherever on during editing 
        
    }
	// Update is called once per frame
	void Update () {

        // Checks animation controller and checks state "Open"
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
        }
        else
        {
            _canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;
        }
	}
}
