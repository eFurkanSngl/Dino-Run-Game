using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public abstract class EventListenerMono: MonoBehaviour
    {
        private void Start()
        {
            RegisterEvents();    
        }

        protected void OnEnable()
        {
            RegisterEvents();
        }

        protected  void OnDisable()
        {
            UnRegisterEvents();
        }

        protected abstract void UnRegisterEvents(); //Override yerde kayıttan çık
         
        protected abstract void RegisterEvents(); // Override yerde kayıt ol
                
    }

