using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenDoorBTN : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => {
            bool isOpen = animator.GetBool("isOpen");
            animator.SetBool("isOpen", !isOpen);
        });
    }
}
