using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


    public abstract class UIBTN:EventListenerMono   // EventListener Monodan Inheritance aldık
    {
        [SerializeField] private Button _button;  

        protected override void RegisterEvents()   // kayıt ediyoruz OnClick
        {
            _button.onClick.AddListener(OnClick);
        }
        protected abstract void OnClick();

        protected override void UnRegisterEvents()  // Kayıt Çık OnClick
        {
            _button.onClick.RemoveListener(OnClick);
        }

      }

