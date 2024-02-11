using UnityEngine;

public class PlayerCannon : Cannon
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Shoot();
    }
}