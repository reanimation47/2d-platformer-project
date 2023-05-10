using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CSCharacterController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator anim;

    public void CharacterPicked()
    {
        anim.SetTrigger("Chosen");
    }

    public void isOnHover(bool _onHover)
    {
        anim.SetBool("OnHover", _onHover);
    }

    public void OnPointerEnter(PointerEventData e)
    {
        isOnHover(true);
    }

    public void OnPointerExit(PointerEventData e)
    {
        isOnHover(false);
    }

}
