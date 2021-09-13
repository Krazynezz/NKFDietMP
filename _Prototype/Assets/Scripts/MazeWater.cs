using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    // Update is called once per frame
    public float Position, Velocity;

    public void Splash(int index, float speed)
    {
        if (index >= 0 && index < springs.Length)
            springs[i].Speed = speed;
    }

    public void Update()
    {
        const float k = 0.025f; // adjust this value to your liking
        float x = Height - TargetHeight;
        float acceleration = -k * x;

        Position += Velocity;
        Velocity += acceleration;

        for (int i = 0; i < springs.Length; i++)
            springs[i].Update(Dampening, Tension);

        float[] leftDeltas = new float[springs.Length];
        float[] rightDeltas = new float[springs.Length];

        // do some passes where springs pull on their neighbours
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < springs.Length; i++)
            {
                if (i > 0)
                {
                    leftDeltas[i] = Spread * (springs[i].Height - springs[i - 1].Height);
                    springs[i - 1].Speed += leftDeltas[i];
                }
                if (i < springs.Length - 1)
                {
                    rightDeltas[i] = Spread * (springs[i].Height - springs[i + 1].Height);
                    springs[i + 1].Speed += rightDeltas[i];
                }
            }

            for (int i = 0; i < springs.Length; i++)
            {
                if (i > 0)
                    springs[i - 1].Height += leftDeltas[i];
                if (i < springs.Length - 1)
                    springs[i + 1].Height += rightDeltas[i];
            }
        }
    }
    */
}
//referenced from https://gamedevelopment.tutsplus.com/tutorials/make-a-splash-with-dynamic-2d-water-effects--gamedev-236
