// Clase Circulo encapsula un dato primitivo: el radio (double)
// Proporciona métodos para calcular el área y el perímetro (circunferencia)

public class Circulo
{
    // Atributo privado para aplicar encapsulamiento
    private double radio;

    // Constructor: inicializa el atributo radio al crear un objeto Circulo
    public Circulo(double radioInicial)
    {
        radio = radioInicial;
    }

    // Propiedad pública para acceder y modificar el radio de forma controlada
    public double Radio
    {
        get { return radio; }
        set { radio = value; }
    }

    // CalcularArea es una función que retorna un valor double.
    // Usa la fórmula: área = π * radio²
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // CalcularPerimetro devuelve el valor del perímetro (circunferencia)
    // Fórmula: perímetro = 2 * π * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}
