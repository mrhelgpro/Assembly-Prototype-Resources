using UnityEngine;
using AssemblyActorCore;

public class InputKeyboard : AssemblyActorCore.Input
{
    void Update()
    {
        GetInput.A = UnityEngine.Input.GetKey(KeyCode.LeftShift) ? Inputable.Key.Press : Inputable.Key.None;

        GetInput.X = UnityEngine.Input.GetKeyDown(KeyCode.Space) ? Inputable.Key.Down : (UnityEngine.Input.GetKey(KeyCode.Space) ? Inputable.Key.Press : Inputable.Key.None);

        Stick();
    }

    private void Stick()
    {
        float vertical = UnityEngine.Input.GetAxis("Vertical");
        float horizontal = UnityEngine.Input.GetAxis("Horizontal");
        float y = GetInput.X == Inputable.Key.Press ? 1 : 0;

        if (Mode == EnumMode.ThirdPerson)
        {
            GetInput.Direction = new Vector3(horizontal, y, vertical);
        }
        else if (Mode == EnumMode.Platformer)
        {
            GetInput.Direction = new Vector3(horizontal, vertical, 0);
            GetInput.Rotation = new Vector3(horizontal, vertical, 0);
        }
        else
        {
            GetInput.Direction = new Vector3(horizontal, 0, vertical);
        }
    }
}