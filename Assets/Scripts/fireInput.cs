using UnityEngine;

public class fireInput : MonoBehaviour
{  
    private Gun _gun;
      void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Con el click izq dispara
        {
            if(GetWeapon()) //Checa primero si hay arma
            {
                _gun.Shoot();
            }
        }

        if(Input.GetMouseButtonDown(1)) //Con click der recarga
        {
            if(GetWeapon())
            {
                _gun.Reload();
            }
        }
    }

    private bool GetWeapon()
    {
        if(_gun == null)
        {
            _gun = gameObject.GetComponent<GetWeapon>()?.Weapon;
        }
        return _gun != null;
    }
}
