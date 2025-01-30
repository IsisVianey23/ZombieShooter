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

    //Animaciones
    [SerializeField]
    private Animator _weaponAnimator;

    //Texto
    private Text _bulletText;


    public void Shoot()
    {
        _weaponAnimator.Play("Shoot", -1, 0f); //Para que la animación de disparo vuelva a reproducirses se agregan el -1, 0f
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation); //Que el arma rote
        _currentBulletNumber--;
        UpdateBulletText();
    }

    public void PickWeapon()
    {
        _totalBulletNumber = _maxBulletNumber;
        _currentBulletNumber = _cartridgeBulletNumber;
        _weaponAnimator.Play("GetWeapon"); //Animación de Agarra pistola
        UpdateBulletText();
    }

    public void Reload()
    {

        if(_totalBulletNumber >= _cartridgeBulletNumber)
        {
            _currentBulletNumber = _cartridgeBulletNumber;
        }
        else if(_totalBulletNumber > 0)
        {
            _currentBulletNumber = _totalBulletNumber;
        }
        _totalBulletNumber -= _currentBulletNumber;
        UpdateBulletText();
    }

    private void UpdateBulletText()
    {
        if(_bulletText == null)
        {
            _bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        }
        _bulletText.text = _currentBulletNumber + "/" + _totalBulletNumber;
    }

}
