using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

class Program
{
    static void Main(string[] args)
    {
    
        Console.WriteLine("\n\n\nNota: El programa examina codigo en lenguaje 'C', ya que en la asignación \n\tno se especifico un lenguaje X para realizar el analisis.");
        
        // Ingresando el codigo en lenguaje 'C' que se analizara
        Console.WriteLine("\n - Ingrese el codigo:");
        string sourceCode = Console.ReadLine();

        Console.Clear(); // Limpiar la pantalla despues de ingresar el codigo en el lenguaje 'C'
        Console.WriteLine($"\n- Codigo ingresado: {sourceCode}");

        // Analizar el código fuente y generar un árbol de sintaxis
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

        // Obtener los diagnósticos de compilación
        var diagnostics = syntaxTree.GetDiagnostics();

        // Variable para verificar si hay errores
        bool hasErrors = false;

        // Recorrer los diagnósticos de compilación
        foreach (var diagnostic in diagnostics)
        {
            // Verificar si el diagnóstico tiene una gravedad de error
            if (diagnostic.Severity == DiagnosticSeverity.Error)
            {
                // Mostrar el diagnóstico de error en la consola
                Console.WriteLine($"\n{diagnostic.ToString()}\n");

                // Establecer hasErrors en true para indicar que hay errores
                hasErrors = true;
            }
        }

        // Verificar si no hay errores y mostrar un mensaje
        if (!hasErrors)
        {
            Console.WriteLine("\n\n - Solución: El código no tiene errores sintácticos.");
        }
    }
}


