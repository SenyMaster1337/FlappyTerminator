using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode KeySpace = KeyCode.Space;
    private const int MouseButtonAttack = 0;

    public bool IsJumpButtonClicked { get; private set; }

    public bool IsAttackButtonClicked { get; private set; }

    private void Update()
    {
        IsJumpButtonClicked = Input.GetKeyDown(KeySpace);

        IsAttackButtonClicked = Input.GetMouseButton(MouseButtonAttack);
    }
}
