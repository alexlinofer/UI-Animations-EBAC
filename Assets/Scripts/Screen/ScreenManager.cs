using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JogoMobile.Singleton;


namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public Screentype startScreen = Screentype.Panel;

        private ScreenBase _currentScreen;

        private void Start()
        {

            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(Screentype type)
        {

            if (_currentScreen != null) _currentScreen.Hide();
            var nextScreen = screenBases.Find(i => i.screenType == type);

            _currentScreen = nextScreen;
            nextScreen.Show();
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }

    }

}
