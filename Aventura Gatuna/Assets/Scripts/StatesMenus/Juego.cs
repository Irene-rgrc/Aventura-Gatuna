using Patterns.State.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Juego : MenuState
    {
        
        GameObject botonPausa;
        public Juego(IMenu menu) : base(menu) { }

        public override void Enter() {
            botonPausa = menu.GetGameObject().transform.Find("BotonPausa").gameObject;
            botonPausa.SetActive(true);
    }
        public override void Exit() {
            botonPausa.SetActive(false);
    }
        public override void Update() { }
            
        public override void FixedUpdate() { }


    }

