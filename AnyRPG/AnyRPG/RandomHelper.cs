using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

public static class RandomHelper
{
    public static Random RandomGenerator = new Random();

    public static Vector3 GeneratePositionXZ(int distance)
    {
        float posX = (RandomGenerator.Next(distance * 201)
           - distance * 100) * 0.01f;
        float posZ = (RandomGenerator.Next(distance * 201)
           - distance * 100) * 0.01f;
        return new Vector3(posX, 0, posZ);
    }
}