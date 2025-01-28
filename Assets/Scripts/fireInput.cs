using UnityEngine;

public class fireInput : MonoBehaviour
{    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<GetWeapon>().Weapon?.Shoot();
        }
    }
}
