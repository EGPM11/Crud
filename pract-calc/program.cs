//SISD (Single Instruction, Single Data): Un solo flujo de instrucciones opera sobre un solo flujo de datos. Es el modelo tradicional de computación secuencial.
//Descripción: Implementa una operación secuencial donde se procesa un solo flujo de datos con un conjunto de instrucciones.

using System;
using System.Collections.Generic;

class Program
{
    static List<int> SISDOperation(List<int> data)
    {
        var result = new List<int>();
        foreach (var item in data)
        {
            result.Add(item * 2); 
        }
        return result;
    }

    static void Main(string[] args)
    {
        List<int> data = new List<int> { 1, 2, 3, 4, 5 };
        List<int> result = SISDOperation(data);
        Console.WriteLine(string.Join(", ", result));  
    }
}

/* SIMD (Single Instruction, Multiple Data): Un solo flujo de instrucciones opera sobre múltiples flujos de datos simultáneamente. 
Se usa en sistemas que procesan grandes conjuntos de datos, como procesamiento de imágenes o operaciones vectoriales.

Descripción: Implementa una operación paralela donde una instrucción actúa sobre múltiples flujos de datos al mismo tiempo.
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static List<int> SIMDOperation(List<int> data)
    {
        var result = new List<int>(new int[data.Count]);

        Parallel.ForEach(data, (item, state, index) =>
        {
            result[(int)index] = item * 2; 
        });

        return result;
    }

    static void Main(string[] args)
    {
        List<int> data = new List<int> { 1, 2, 3, 4, 5 };
        List<int> result = SIMDOperation(data);
        Console.WriteLine(string.Join(", ", result));
    }
}

/**MIMD (Multiple Instruction, Multiple Data): Múltiples flujos de instrucciones operan sobre múltiples flujos de datos simultáneamente. Es el modelo más general de sistemas paralelos, como los sistemas multiprocesadores.
 Descripción: Implementa un sistema donde diferentes hilos o tareas procesan diferentes flujos de datos con diferentes instrucciones.
**/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static List<int> SquareOperation(List<int> data)
    {
        var result = new List<int>();
        foreach (var item in data)
        {
            result.Add(item * item); 
        }
        return result;
    }

    static List<int> MultiplyBy10Operation(List<int> data)
    {
        var result = new List<int>();
        foreach (var item in data)
        {
            result.Add(item * 10); 
        }
        return result;
    }

    static async Task Main(string[] args)
    {
        List<int> data1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> data2 = new List<int> { 6, 7, 8, 9, 10 };

        var task1 = Task.Run(() => SquareOperation(data1)); 
        var task2 = Task.Run(() => MultiplyBy10Operation(data2)); 

        var result1 = await task1;
        var result2 = await task2;

        Console.WriteLine("Resultado de elevar al cuadrado: " + string.Join(", ", result1));  
        Console.WriteLine("Resultado de multiplicar por 10: " + string.Join(", ", result2));  
    }
}
