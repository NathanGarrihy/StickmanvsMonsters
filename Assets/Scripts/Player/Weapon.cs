using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    // public & serialized fields
    [SerializeField] private AudioClip gunshot;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Sound controller intake
    private SoundController sc;

    // Start is called before the first frame update
    private void Start()
    {
        sc = SoundController.FindSoundController();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) {   //  Makes clicking buttons not trigger shoot
        if (Input.GetButtonDown("Fire1"))
        {
            sc.PlayOneShot(gunshot);
            Shoot();
        }
    }
    }

    //  Method called to shoot
    private void Shoot ()
    {
        //  Shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}


