using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer; // Renderiza la imagen, controla a la imagen, asi cualquier parte puede acceder a ella
    public Sprite[] sides; //Array de los reversos de la cara
    int flipCount = 1; // Si empieza en 0 sale la 1 cara dos veces por el restoç

    private enum LadoMoneda
    {
        Cara,
        Cruz
    }

    // Prueba de que funciona el array de size
    private void OnMouseDown() // Cuando pulse el boton
    {
        // Establece un número aleatorio de giros entre 5 y 10
        int girosTotales = Random.Range(2, 11);
        //spriteRenderer.sprite = sides[1]; // 0 es figura 1 es cruz
        StartCoroutine(FlipAnimation(0.04f, 0.5f, girosTotales));
    }
    // Aniacion de flip de la moneda
    IEnumerator FlipAnimation(float duration, float size, int girosTotales) // Se mete size para hacer mas pequeña la moneda para la animacion
    {
        for (int i = 0; i < girosTotales; i++)
        {
            // Gira hacia un lado aleatorio en cada iteración
            ChangeSpriteRandomly();

            while (size > 0.1)
            {
                size -= 0.07f;
                ChangeScale(size);
                yield return new WaitForSeconds(duration);
            }

            // Al final de cada giro, vuelve al tamaño original
            while (size < 0.99)
            {
                size += 0.07f;
                ChangeScale(size);
                yield return new WaitForSeconds(duration);
            }
        }

        // Al final de los giros, muestra el resultado final
        //ChangeSprite(); // Cambia la cara de la moneda antes de mostrar el resultado
        spriteRenderer.sprite = sides[flipCount % 2];
        flipCount++;
        /*
        while (size > 0.1)
        {
            size = size - 0.07f; // float
            transform.localScale = new Vector3(1, size, 1); // Solo cambiamos en el eje Y
            yield return new WaitForSeconds(duration);
        }
        // Hay que hacer un flip
        //spriteRenderer.sprite = sides[flipCount % 2]; // Nos da los restos de la division de flipCount entre 2
        ChangeSprite();

        while (size < 0.99) // Va a crecer
        {
            size = size + 0.07f;
            //transform.localScale = new Vector3(1, size, size);
            ChangeScale(size);
            yield return new WaitForSeconds(duration);
        }
        flipCount++;
        */
    }

    void ChangeSprite()
    {
        LadoMoneda ladoActual = (LadoMoneda)(flipCount % 2);
        spriteRenderer.sprite = sides[ladoActual == LadoMoneda.Cara ? 0 : 1];
        // Alterna entre cara y cruz sin importar el estado actual
    }

    void ChangeScale(float newSize)
    {
        transform.localScale = new Vector3(1, newSize, newSize);
    }

    void ChangeSpriteRandomly()
    {
        // Cambia la cara o cruz de forma aleatoria mientras gira
        spriteRenderer.sprite = sides[Random.Range(0, 2)];
    }

    // Nos aseguramos que hay un programa ejecutandose.
    private void Awake() // una vez que el ordenador se despierta
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Le pregunta al ordenador si esta funcionando y si lo esta que me de las imagenes sprites de renderizado
    }
}