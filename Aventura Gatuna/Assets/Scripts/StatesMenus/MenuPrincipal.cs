using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State.Interfaces
{

    public class MenuPrincipal :MenuState
    {
        GameObject menuPrincipal;
        public MenuPrincipal(IMenu menu) : base(menu) { }

        public override void Enter() {
            menuPrincipal = menu.GetGameObject().transform.Find("MenuPrincipal").gameObject;
            menuPrincipal.SetActive(true);
        }
        public override void Exit() {
            menuPrincipal.SetActive(false);
        }
        public override void Update() { }
        public override void FixedUpdate() { }

       
    }
}
