using Ebac.Core.Singleton;
using Screens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{


    public class ScreenManager : Singleton<ScreenManager>
    {

        public List<ScreensBase> screens;
        public ScreenType startscreen = ScreenType.Panel;

        private ScreensBase _currentscreen;




        private void Start()
        {
            //HideAll();
            ShowByType(startscreen);

        }


        public void ShowByType(ScreenType type)
        {
                if (_currentscreen != null) _currentscreen.Hide();

                var nextScreen = screens.Find(i => i.screenType == type);
                nextScreen.Show();
                _currentscreen =  nextScreen;

        }



        public void HideAll()
        {
            screens.ForEach(i => i.Hide());

        }

    }

}