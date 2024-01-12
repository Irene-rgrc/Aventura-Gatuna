using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
namespace Patterns.State.Interfaces
{

    public class MenuController : MonoBehaviour, IMenu
    {
        public bool estaJugando = false;
        public IState currentState;
        public GameObject GetGameObject() {
            return this.gameObject;
        }
        public void SetState(IState state)
        {
            if (this.currentState != null) { 
            this.currentState.Exit();
        }
            this.currentState = state;  
            this.currentState.Enter();

        }

        public IState GetState() {
            return this.currentState;
        }

        public void Awake() {
            Time.timeScale = 0f;
            SetState(new MenuPrincipal(this));
        }
        public void Update() {
            this.currentState.Update();
            if (Time.timeScale == 1.0f)
            {
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    SetState(new MenuPausa(this));
                    Time.timeScale = 0f;
                }
            }
        }
        public void FixedUpdate() {
            this.currentState.FixedUpdate();
        }


        public void Jugar()
        {
            currentState.Exit();
            Time.timeScale = 1.0f;
            SetState(new Juego(this));
            estaJugando = true;
        }
        public void Ajustes()
        {
            SetState(new MenuAjustes(this));    
        }

        public void AjustesPausa()
        {
            SetState(new MenuAjustesPausa(this));
        }

        public void Creditos()
        {
            SetState(new Creditos(this));
        }

        public void Atras()
        {
            if (estaJugando==false) {
                SetState(new MenuPrincipal(this));
            }
            else {
                SetState(new MenuPausa(this));
            }

        }
        public void Pausa()
        {
            SetState(new MenuPausa(this));
            Time.timeScale = 0f;
        }

       public void Salir()
        {
            estaJugando = false;
            SetState(new MenuPrincipal(this));
        }
        public void VolverJuego()
        {
            estaJugando = true;
            SetState(new Juego(this));
            Time.timeScale = 1.0f;
        }

    }
}