// Clase Rectangulo encapsula datos primitivos: base y altura (double)
// Proporciona métodos para calcular el área y el perímetro

public class Rectangulo
{
    private double baseRect;   // base del rectángulo
    private double altura;     // altura del rectángulo

    // Constructor con dos parámetros (base y altura)
    public Rectangulo(double baseInicial, double alturaInicial)
    {
        baseRect = baseInicial;
        altura = alturaInicial;
    }

    // Propiedades públicas para acceder a los atributos encapsulados
    public double Base
    {
        get { return baseRect; }
        set { baseRect = value; }
    }

    public double Altura
    {
        get { return altura; }
        set { altura = value; }
    }

    // CalcularArea retorna un double con el resultado de base * altura
    public double CalcularArea()
    {
        return baseRect * altura;
    }

    // CalcularPerimetro retorna el valor del perímetro del rectángulo
    // Fórmula: P = 2 * (base + altura)
    public double CalcularPerimetro()
    {
        return 2 * (baseRect + altura);
    }
}
