using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer; // Renderiza la imagen, controla a la imagen, asi cualquier parte puede acceder a ella
    public Sprite[] sides; //Array de los reversos de la cara
    int flipCount = 1; // Si empieza en 0 sale la 1 cara dos veces por el resto

    // Prueba de que funciona el array de size
    private void OnMouseDown() // Cuando pulse el boton
    {
        //spriteRenderer.sprite = sides[1]; // 0 es figura 1 es cruz
        StartCoroutine(WaitPlease(0.0001f, 1.0f));
    }
    // Aniacion de flip de la moneda
    IEnumerator WaitPlease(float duration, float size) // Se mete size para hacer mas pequeña la moneda para la animacion
    {
        while(size > 0.1)
        {
            size = size - 0.07f; // float
            transform.localScale = new Vector3(1, size, 1); // Solo cambiamos en el eje Y
            yield return new WaitForSeconds(duration);
        }
        // Hay que hacer un flip
        spriteRenderer.sprite = sides[flipCount % 2]; // Nos da los restos de la division de flipCount entre 2
        while (size < 0.99) // Va a crecer
        {
            size = size + 0.07f;
            transform.localScale = new Vector3(1, size, size);
            yield return new WaitForSeconds(duration);
        }
        
        flipCount++;
    
    }
    // Nos aseguramos que hay un programa ejecutandose.
    private void Awake() // una vez que el ordenador se despierta
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Le pregunta al ordenador si esta funcionando y si lo esta que me de las imagenes sprites de renderizado
    }
}
