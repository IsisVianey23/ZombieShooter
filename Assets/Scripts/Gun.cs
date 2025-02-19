using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
   [SerializeField]
   private GameObject _bullet;

    [SerializeField]
    private Transform _bulletPivot;

    //Balas y cartuchos
    [SerializeField]
    private int _maxBulletNumber = 20;
    [SerializeField]
    private int _cartridgeBulletNumber = 5;
    private int _totalBulletNumber = 0;
    private int _currentBulletNumber = 0;
    private GetWeapon _getWeapon;

    //Animaciones
    [SerializeField]
    private Animator _weaponAnimator;

    //Texto
    private Text _bulletText;

   

    public void PickWeapon(GetWeapon getWeapon)
    {
        _getWeapon = getWeapon;
        _totalBulletNumber = _maxBulletNumber;
        Reload();
        _weaponAnimator.Play("GetWeapon"); //Animación de Agarra pistola
        UpdateBulletText();
    }

     public void Shoot()
    {
        if(_currentBulletNumber == 0) //Cuando las balas sean igual a cero, deja de disparar.
        {
            if(_totalBulletNumber == 0)
            {
                RemoveWeapon(); //Llama al metodo publico que destruye la pistola cuando se acaban las balas.
            }
            return;
        }

        SoundManager.instance.Play("shoot");
        _weaponAnimator.Play("Shoot", -1, 0f); //Para que la animación de disparo vuelva a reproducirse se agregan el -1, 0f
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation); //Que el arma rote
        _currentBulletNumber--;
        UpdateBulletText();
    }

    public void Reload()
    {

       if(_currentBulletNumber == _cartridgeBulletNumber || _totalBulletNumber == 0)
       {
            return;
       }

       int bulletNeeded = _cartridgeBulletNumber - _currentBulletNumber;
       
        if(_totalBulletNumber >= _cartridgeBulletNumber)
        {
            _currentBulletNumber = bulletNeeded;
        }
        else if(_totalBulletNumber > 0)
        {
            _currentBulletNumber = _totalBulletNumber;
        }
        SoundManager.instance.Play("reload");
        _totalBulletNumber -= _currentBulletNumber;
        _weaponAnimator.Play("Reload", -1, 0f);
        UpdateBulletText();
    }

    private void UpdateBulletText()
    {
        if(_bulletText == null)
        {
            _bulletText = _getWeapon.GetComponent<UIController>().BulletsText;
        }
        _bulletText.text = _currentBulletNumber + "/" + _totalBulletNumber;
    }

 private void RemoveWeapon()
    {
        _getWeapon.RemoveWeapon();
        _getWeapon = null;
    }
}
