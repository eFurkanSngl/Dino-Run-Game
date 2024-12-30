using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace Assets.Scripts.Events
{
    public static class GameEvents
    {
        public static UnityAction OnNewGame;  // Obsver Pattern
        // NewGame bir olay buna dışardan kayıt olanların işlemlerini hepsini dinlemesine observer pattern deriz
        
       
    }
}
