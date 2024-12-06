using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    [SerializeField]Image reloadingImage;
    [SerializeField] TextMeshProUGUI label;

    [SerializeField] Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (label != null && weapon != null)
        {
            if (!weapon.isReloading)
            {
                if (reloadingImage.gameObject.activeSelf)
                {
                    reloadingImage.gameObject.SetActive(false);
                }
                label.text = string.Format("Ammo: {0}/{1}", weapon.GetAmmo(), weapon.magazineSize);
            } else
            {
                label.text = string.Format("Reloading...");
                if (!reloadingImage.gameObject.activeSelf)
                {
                    reloadingImage.gameObject.SetActive(true);
                }
                reloadingImage.fillAmount = (weapon.GetCurrentReloadingDuration() / weapon.reloadingDuration);
            }
        }
    }
}
