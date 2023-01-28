using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldableButton : Button
{
    public bool IsHold { get; private set; }

    protected override void OnEnable() => IsHold = false;

    public override void OnPointerDown(PointerEventData eventData) => IsHold = true;

    public override void OnPointerUp(PointerEventData eventData) => IsHold = false;
}
