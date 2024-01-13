using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State.Interfaces
{

    public class EscenaIntro : MenuState
    {
        GameObject intro;
        public EscenaIntro(IMenu menu) : base(menu) { }

        public override void Enter()
        {
            intro = menu.GetGameObject().transform.Find("Introduccion").gameObject;
            intro.SetActive(true);
        }
        public override void Exit()
        {
            intro.SetActive(false);
        }
        public override void Update() { }
        public override void FixedUpdate() { }


    }
}
