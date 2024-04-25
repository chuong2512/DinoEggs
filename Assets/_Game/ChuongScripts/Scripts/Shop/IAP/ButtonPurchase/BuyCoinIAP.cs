using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public class BuyCoinIAP : ValuePurchase
    {
        [SerializeField] private TextMeshProUGUI value1TMP;
        [SerializeField] private int value1;

        protected override void Setup()
        {
            value1TMP.SetText(value1.ToString());
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            Data.Player.Coin += value1;
            Data.Player.Gem += value;
        }
    }
}