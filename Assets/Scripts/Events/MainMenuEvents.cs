using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class MainMenuEvents: MonoBehaviour
    {

        public static UnityAction NewGameBTN;
        public static UnityAction SettingsBTN;
        public static UnityAction HighScoreBTN;
        public static UnityAction ExitBTN;
    }
}
// observer pattern