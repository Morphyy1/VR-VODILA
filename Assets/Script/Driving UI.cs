using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DrivingUI : MonoBehaviour
{
    public Image UI;
    public Sprite N;
    public Sprite D;
    public Sprite R;
    public Sprite P;

    private static Sprite _currentSprite;

    private void Start()
    {
        _currentSprite = N;
    }

    private void Update()
    {
        var keysUp = Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.UpArrow);
        var keysDown = Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.DownArrow);

        if (RearWheelDrive.isBraking)
            UI.sprite = P;
        else if (!RearWheelDrive.isBraking)
            UI.sprite = _currentSprite;

        if (keysUp)
        {
            if (_currentSprite == N)
                SwapImage(D);

            if (_currentSprite == R)
                SwapImage(N);
        }

        if (keysDown)
        {
            if (_currentSprite == N)
                SwapImage(R);
            if (_currentSprite == D)
                SwapImage(N);
        }
    }

    private void SwapImage(Sprite value)
    {
        UI.sprite = value;
        _currentSprite = value;
        GetCurrentSprite();
    }

    public static char GetCurrentSprite() => _currentSprite.ToString()[0];
}
