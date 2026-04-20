// Desarrollar un programa en C# que permita simular el funcionamiento básico de una cuenta bancaria.

// Para ello, crear una clase llamada CuentaBancaria que contenga:

// Un atributo privado para el saldo.
// Un atributo público para el titular de la cuenta.

// La clase debe incluir:

// Un constructor sin parámetros que asigne un titular por defecto (“Usuario sin Nombre”) y saldo inicial en 0.
// Un constructor con parámetro que permita establecer el nombre del titular, con saldo inicial en 0.
// Una propiedad para el saldo que impida asignar valores negativos.

// Además, implementar los siguientes métodos:

// Depositar: que permita ingresar dinero a la cuenta (solo montos positivos).
// Retirar: que permita extraer dinero de la cuenta (solo montos positivos).
// TransferirA: que permita transferir dinero a otra cuenta, verificando que haya fondos suficientes.
// EstadoDeCuenta: que muestre el saldo actual y el titular.

// En el método principal (Main):

// Crear dos objetos de tipo CuentaBancaria.
// Realizar operaciones de depósito, retiro y transferencia entre cuentas.
// Mostrar el estado final de cada cuenta por pantalla.

using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        CuentaBancaria hola = new CuentaBancaria("karen",300.0m);
        CuentaBancaria hola2 = new CuentaBancaria("elpe", 400.0m);
        hola.Depositar(300.0m);
        hola.Transferir(200.0m, hola2);
        hola.Retirar(400.0m);
        hola.Mostrar();
        hola.EstadoDeCuenta();
        hola2.Mostrar();
        hola2.EstadoDeCuenta();
        decimal montoDeposito = decimal.Parse(Console.ReadLine());
        hola.Depositar(montoDeposito);
        hola.Mostrar();
    }
}

class CuentaBancaria
{
    private decimal saldo;

    public decimal Saldo
    {
        get{return saldo;}
        set
        {
            if(value >= 0)
            {
                saldo = value;
            }
            else
            {
                Console.WriteLine("no es valor valido");
            }
        }
    }
    public string titular;

    public CuentaBancaria()
    {
        titular = "Usuario sin nombre";
        saldo = 0.0m;
    }

    public CuentaBancaria(string titular, decimal saldo)
    {
        this.titular = titular;
        this.Saldo = saldo;
    }
    public void Mostrar()
    {
        Console.WriteLine(titular);
        Console.WriteLine(saldo);
    }
    public CuentaBancaria(string karen)
    {
        titular = karen;
        saldo = 0.0m;
    }

    public bool Depositar(decimal monto)
    {
        bool sepudo;

        if(monto >= 0)
        {
            saldo += monto;
            sepudo = true;
        }
        else
        {
            Console.WriteLine("no podes");
            sepudo = false;
        }
        return sepudo;
    }
    public bool Retirar(decimal monto)
    {
        if(monto >= 0 && saldo >= monto)
        {
            saldo -= monto;
            return true;
        }
        else
        {
            Console.WriteLine("no se pudo");
            return false;
        }
    }
    public void Transferir(decimal monto, CuentaBancaria cuenta)
    {
        if(this.Retirar(monto))
        {
            cuenta.Depositar(monto);
        }
    }
    public void EstadoDeCuenta()
    {
        Console.WriteLine($"El saldo actual es:{this.saldo} y el titular es:{this.titular}");
    }
}

