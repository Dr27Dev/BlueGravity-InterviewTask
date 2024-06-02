using UnityEngine;

public class InputHint : MonoBehaviour
{
    private void Update()
    {
        if (PlayerController.Instance.Input.MovementAxis.magnitude > 0) gameObject.SetActive(false);
    }
}
