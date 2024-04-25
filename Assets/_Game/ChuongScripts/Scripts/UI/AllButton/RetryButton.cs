using UnityEngine;

namespace ChuongCustom
{
    public class RetryButton : AButton
    {
        protected override void OnClickButton()
        {
            Time.timeScale = 1;
            Manager.InGame.Retry();
        }

        protected override void OnStart()
        {
        }
    }
}