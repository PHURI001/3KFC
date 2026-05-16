using TMPro;
using UnityEngine;

public class GunList : MonoBehaviour
{
    PlayerData playerData;

    public TMP_Text nameText;
    public TMP_Text priceText;
    public TMP_Text ButtonText;

    GunInfo _gunInfo;

    private void Start()
    {
        playerData = GameManager.Instance.PlayerData;
    }

    public void UpdateInfo(GunInfo gunInfo)
    {
        _gunInfo = gunInfo;

        nameText.text = gunInfo.Name;
        priceText.text = "$" + gunInfo.Price.ToString();

        if (playerData.GetGunUnlock().Contains(gunInfo.ID))
        {
            ButtonText.text = "Sellect";
        }
        else
        {
            ButtonText.text = "Buy";
        }

        if (gunInfo.ID == playerData.CurrentGun())
        {
            ButtonText.text = "Equipped";
        }
    }

    public void Buy()
    {
        if (playerData.GetGunUnlock().Contains(_gunInfo.ID))
        {
            Sellect();
            return;
        }
        else if (playerData.GetCoins() < _gunInfo.Price)
        {
            return;
        }

        playerData.SpendCoin(_gunInfo.Price);
        playerData.UnlockGun(_gunInfo.ID);
        Sellect();
    }

    public void Sellect()
    {
        playerData.SetGun(_gunInfo.ID);
    }
}
