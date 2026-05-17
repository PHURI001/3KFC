using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GunStorage : MonoBehaviour
{
    PlayerData playerData;
    public int price = 100;
    public TMP_Text[] GunName;
    public TMP_Text[] BulletName;

    private void Start()
    {
        playerData = GameManager.Instance.PlayerData;

        for (int i = 0; i < GunName.Length; i++)
        {
            if (playerData.CurrentGun() == i + 1)
            {
                GunName[i].text = "Select";
            }
            else if (playerData.GetGunUnlock().Contains(i + 1))
            {
                GunName[i].text = "Unlock";
            }
            else
            {
                GunName[i].text = "Buy";
            }
        }

        for (int i = 0; i < BulletName.Length; i++)
        {
            if (playerData.CurrentBullet() == i + 1)
            {
                BulletName[i].text = "Select";
            }
            else if (playerData.GetBulletUnlock().Contains(i + 1))
            {
                BulletName[i].text = "Unlock";
            }
            else
            {
                BulletName[i].text = "Buy";
            }
        }
    }

    public void BuyGun(int index) { BuyAndSellect(true, index); }
    public void BuyBullet(int index) { BuyAndSellect(false, index); }

    //type 0 = gun, 1 = bullet
    public void BuyAndSellect(bool type, int index)
    {
        for (int i = 0; i < GunName.Length; i++)
        {
            if (playerData.GetGunUnlock().Contains(i + 1))
            {
                GunName[i].text = "Unlock";
            }
            else
            {
                GunName[i].text = "Buy";
            }
        }

        for (int i = 0; i < BulletName.Length; i++)
        {
            if (playerData.GetBulletUnlock().Contains(i + 1))
            {
                BulletName[i].text = "Unlock";
            }
            else
            {
                BulletName[i].text = "Buy";
            }
        }

        if (type)
        {
            if (playerData.GetGunUnlock().Contains(index))
            {
                playerData.SetGun(index);
            }
            else
            {
                if (playerData.GetCoins() < price)
                {
                    return;
                }
                playerData.SpendCoin(price);
                playerData.UnlockGun(index);
                playerData.SetGun(index);
            }
        }
        else if (!type)
        {
            if (playerData.GetBulletUnlock().Contains(index))
            {
                playerData.SetBullet(index);
            }
            else
            {
                if (playerData.GetCoins() < price)
                {
                    return;
                }
                playerData.SpendCoin(price);
                playerData.UnlockBullet(index);
                playerData.SetBullet(index);
            }
        }

        GunName[playerData.CurrentGun() - 1].text = "Sellect";
        BulletName[playerData.CurrentBullet() - 1].text = "Sellect";
    }
}
