using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HideHand : MonoBehaviour
{
    public GameObject Lefthand;
    public GameObject Righthand;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable=GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideHandOnEnter);
        grabInteractable.selectExited.AddListener(ShowHandOnExit);
    }
    public void HideHandOnEnter(SelectEnterEventArgs arg)
    {
        if (arg.interactorObject.transform.tag == "RightHand")
        {
            Righthand.SetActive(false);
        }
        else if (arg.interactorObject.transform.tag == "LeftHand")
        {
            Lefthand.SetActive(false);
        }
    }
    public void ShowHandOnExit(SelectExitEventArgs arg)
    {
        if (arg.interactorObject.transform.tag == "RightHand")
        {
            Righthand.SetActive(true);
        }
        else if (arg.interactorObject.transform.tag == "LeftHand")
        {
            Lefthand.SetActive(true);
        }
    }
}
