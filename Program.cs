// See https://aka.ms/new-console-template for more information

/*
 * Universidad Nacional Abierta y a Distancia (UNAD)
 * Escuela de Ciencias Básicas, Tecnología e Ingeniería – ECBTI
 * Programación (213023_137)
 * Autor: Alfonso Gonzalez Posso
 * Etapa 5 - Implementación de una solución funcional
 *
 */

using CajeroAutomatico.Cajero;
using CajeroAutomatico.Usuario;

Usuario objUsusario = new Usuario();
Cajero objCajero = new Cajero();

Boolean isSalirMenu = true;

while (isSalirMenu)
{
    try
    {
        Console.Clear();
        Console.WriteLine(
            "\t* Universidad Nacional Abierta y a Distancia (UNAD) \n" +
            "\t* Escuela de Ciencias Básicas, Tecnología e Ingeniería – ECBTI \n" +
            "\t\t* Programación (213023_137) \n" +
            "\t\t* Autor: Alfonso Gonzalez Posso \n" +
            "\t\t* Etapa 5 - Implementación de una solución funcional \n"
        );
        Console.Write("\t#####---######--> Menu Cajero Automático <-- #####---######");
        Console.Write("\n\t\t1. Ingresar al Cajero.");
        Console.Write("\n\t\t2. Registrarse.");
        Console.Write("\n\t\t3. Recuperar Contraseña.");
        Console.Write("\n\t\t4. Listar los Usuarios.");
        Console.Write("\n\t\t5. Salir del Programa.");
        Console.Write("\n\nIngrese el numero de la opción deseada: ");
        int opcionMenu = Int32.Parse(Console.ReadLine());

        switch (opcionMenu)
        {
            case 1:
            {
                Console.WriteLine("#####---######--> Ingresar al Cajero <-- #####---######");
                Console.Write("Ingrese Username -> ");
                string username = Console.ReadLine();
                Console.Write("Ingrese Password -> ");
                string password = Console.ReadLine();

                bool isLogin = objUsusario.Login(username.ToLower(), password);

                if (isLogin)
                {
                    int GetIDUser = objUsusario.ObtenerIDUser(username);
                    
                    objUsusario.OperarCajeroU(username, GetIDUser);
                    //objCajero.OperarCajero(username, GetIDUser);

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Error::Usuario o Contraseña incorrecto");
                    Console.ReadKey();
                }

                break;
            }
            case 2:
            {
                Console.WriteLine("\n#####---######--> Registrarse <--#####---######.\n");

                Console.Write("Ingrese el Nombre -> ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese el Apellido -> ");
                string apellido = Console.ReadLine();

                Console.Write("Ingrese el Username -> ");
                string username = Console.ReadLine();
                Boolean Existe = objUsusario.ExisteUser(username.ToLower());
                if (Existe)
                {
                    Console.WriteLine(
                        "Error: El usuario no se puede registrar.\nPor favor ingrese otro un usuario diferente.\n");
                    Console.ReadKey();
                    break;
                }

                Console.Write("Ingrese la Contraseña -> ");
                string password = Console.ReadLine();
                Console.Write("Ingrese la Dirección -> ");
                string direccion = Console.ReadLine();
                Console.Write("Ingrese el Telefono -> ");
                int telefono = Int32.Parse(Console.ReadLine());

                int totalIdUser = objUsusario.TotalUsuarios();
                totalIdUser = totalIdUser + 1;

                string numeroClienteCuenta = totalIdUser+"90219-8"+totalIdUser;

                objUsusario.AgregarUnUsuario(totalIdUser, nombre, apellido, username.ToLower(), password, direccion, telefono, numeroClienteCuenta, saldoc: 0, puntosvivaColombia: 0, limiteretiro: 0);
                Console.WriteLine("\nRegistro exitoso.\n");

                Console.ReadKey();
                break;
            }
            case 3:
            {
                Console.WriteLine("\n#####---######--> Recuperar Contraseña <--#####---######.\n");

                Console.Write("Por favor ingrese su Username->  ");
                string username = Console.ReadLine();

                bool isCorrectUser = objUsusario.RecuperarUsernamePass(username.ToLower());

                if (isCorrectUser)
                {
                    int GetIDUser = objUsusario.ObtenerIDUser(username);

                    Console.Write("Ingrese Su Nuevo Password-> ");
                    string newpassword = Console.ReadLine();

                    objUsusario.RecuperarUserPass(GetIDUser, username, newpassword);
                }
                else
                {
                    Console.WriteLine("Error: No se puede recuperar la contraseña del usuario ingresado.\n");
                }

                Console.ReadKey();
                break;
            }
            case 4:
            {
                Console.WriteLine("Listar los Usuarios.");
                objUsusario.ListarUsuarios();
                Console.WriteLine("\nPara ver sus cuentas registradas.");
                Console.ReadKey();
                break;
            }
            case 5:
            {
                Console.WriteLine("Cerraste Sesión Correctamente.\n");
                isSalirMenu = false;
                break;
            }
            default:
            {
                Console.WriteLine("Ingresaste un valor incorrector.\nPor favor vuelve a validar.");
                Console.ReadKey();
                break;
            }
        }
    }
    catch (Exception error)
    {
        Console.WriteLine("Error: {0}", error.Message);
        Console.ReadKey();
    }
}