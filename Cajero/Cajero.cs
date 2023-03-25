
namespace CajeroAutomatico.Cajero
{
    internal class Cajero
    {
        Usuario.Usuario _objUsuario = new CajeroAutomatico.Usuario.Usuario();
        
        private float _saldo = 0;
        private float _limiteDiarioRetiro = 2000000;
        private float _saldoRetirado = 0;

        public float Saldo
        {
            get => _saldo;
            set => _saldo = value;
        }
        
        public float LimiteDiarioRetiro
        {
            get => _limiteDiarioRetiro;
            set => _limiteDiarioRetiro = value;
        }

        public float SaldoRetirado
        {
            get => _saldoRetirado;
            set => _saldoRetirado = value;
        }

        public void OperarCajero(string user, int idUser)
        {
            
            Console.Clear();
            Console.WriteLine("\t\t##===================================##");
            Console.WriteLine("\t\t##\tUsuario: {0}", user.ToUpper());
            Console.WriteLine("\t\t##\tId Usuario: {0}", idUser);
            Console.WriteLine("\t\t##===================================##\n");
            
            Boolean isSalir = true;

            while (isSalir)
            {
                try
                {
                    Console.WriteLine("\tManu Principal Cajero Automatico.\n");
                    Console.WriteLine("\t\t1. Consultar saldo.");
                    Console.WriteLine("\t\t2. Agregar saldo a la cuenta.");
                    Console.WriteLine("\t\t3. Retirar.");
                    Console.WriteLine("\t\t4. Transferencias entre cuentas del mismo banco.");
                    Console.WriteLine("\t\t5. Consulta de puntos ViveColombia.");
                    Console.WriteLine("\t\t6. Canje de puntos ViveColombia.");
                    Console.WriteLine("\t\t7. Salir del Cajero.\n");
                    Console.Write("\tSeleccione una opción -> ");
                    int opc = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("\tConsulta de saldo.\n");
                            Saldo = _objUsuario.ConsultarSaldo(idUser: idUser);
                            Console.WriteLine("\tSaldo disponible: $ {0} COP", Saldo);
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("\tAgregar saldo.\n");
                            Console.Write("\tSaldo a ingresar: ");
                            float saldoIngresar = float.Parse(Console.ReadLine());

                            if (saldoIngresar < 0)
                            {
                                Console.WriteLine("\tNo puedes ingresar un sado negativo.");
                            }
                            else if(saldoIngresar >= 3000000)
                            {
                                Console.WriteLine("\tEl saldo ingresado es muy grande, por favor acerquese a caja.");
                            }
                            else
                            {
                                Saldo = _objUsuario.AgregarSaldo(idUser: idUser, saldoAgregar: saldoIngresar);
                                _objUsuario.AgregarPuntosViveColombia(idUser: idUser);
                                //Console.WriteLine("\tTu nuevo saldo es: $ {0} COP", Saldo);  
                                Console.WriteLine("\tSaldo agregado exitosamente.");
                            }
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("\tRetirar Saldo.\n");
                            //Console.WriteLine("\tTu saldo disponible es: $ {0} COP", Saldo);
                            Console.Write("\tIngresa el valor a retirar: ");
                            float saldoRetirar = float.Parse(Console.ReadLine());
                            if (saldoRetirar >= Saldo)
                            {
                                Console.WriteLine("\tEl valor a retirar no puede ser mayor al saldo disponible.");
                                Console.WriteLine("\tPor favor ingrese otro valor.");
                            }
                            else if (SaldoRetirado == LimiteDiarioRetiro)
                            {
                                Console.WriteLine("\tLimite de retiro diario alcanzado por cajero.");
                                Console.WriteLine("\tPor favor acercarse a caja.");
                            }else if (saldoRetirar < 0)
                            {
                                Console.WriteLine("\tPor favor ingrese un saldo válido.");
                            }
                            else
                            {
                                Saldo = _objUsuario.RetirarSaldo(idUser: idUser, saldoRetirar: saldoRetirar);
                                SaldoRetirado += saldoRetirar;
                                _objUsuario.AgregarPuntosViveColombia(idUser: idUser);
                                Console.WriteLine("\tSaldo retirado exitosamente.");
                                //Console.WriteLine("Tu nuevo saldo es: {0}", Saldo);
                                //Console.WriteLine("Total retiro diario  es: {0}", SaldoRetirado);
                            }
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("\tTransferencias entre cuentas del mismo banco.\n");
                            /*
                            int isCorrect = 0;
                            do
                            {
                                Console.WriteLine("\tPor favor ingrese el numero de cuenta para el envio.");
                                Console.Write("\t\tCuenta N°: ");
                                //string cuentaDestino = Console.ReadLine();
                                Console.WriteLine("\tLa cuenta ingresada es correcta.?");
                                Console.WriteLine("\t1. SI.");
                                Console.WriteLine("\t2. NO.");
                                Console.Write("\tCual es su elección: ");
                                isCorrect = Int32.Parse(Console.ReadLine());
                            } while (isCorrect != 1);
                            */
                            Console.WriteLine("\tPor favor ingrese el numero de cuenta para el envio.");
                            Console.Write("\t\tCuenta N°: ");
                            string cuentaDestino = Console.ReadLine();
                            
                            bool validarCuenta = _objUsuario.ValidarCuenta(numeroCuenta: cuentaDestino);

                            if (validarCuenta)
                            {
                                bool validarCuentaUser = _objUsuario.ValidarCuentaUser(idUser: idUser, numeroCuenta: cuentaDestino);
                                if (!validarCuentaUser)
                                {
                                    Console.Write("\tPor favor ingrese el monto a enviar: ");
                                    float montoEnviar = Int32.Parse(Console.ReadLine());
                                    Saldo = _objUsuario.ConsultarSaldo(idUser: idUser);

                                    if (montoEnviar >= Saldo)
                                    {
                                        Console.WriteLine("\tError: El valor a enviar no puede ser mayor que el de tu cuenta.");
                                    }else if (montoEnviar < 0)
                                    {
                                        Console.WriteLine("\tError: El valor a enviar no puede ser negativo o cero.");
                                    }
                                    else
                                    {
                                        _objUsuario.EnviarSaldo(numerocuenta: cuentaDestino, enviarsaldo: montoEnviar);
                                        Saldo = _objUsuario.RetirarSaldo(idUser: idUser, saldoRetirar: montoEnviar);
                                        _objUsuario.AgregarPuntosViveColombia(idUser: idUser);
                                        Console.WriteLine("\tEl envio fue exitoso.");
                                        Console.WriteLine("\tEl monto enviado fue: {0} COP", montoEnviar);
                                        Console.WriteLine("\tSu nuevo saldo dispoible es: {0} COP", Saldo);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\tLa cuenta ingresada no puede ser la de tu usuario.");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("\tError: La cuenta ingresada no esta registrada.");
                            }

                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("\tConsulta de puntos ViveColombia.\n");
                            float puntos = _objUsuario.ConsultarPuntosViveColombia(idUser: idUser);
                            Console.WriteLine("\tPara el Usuario: {0}", user.ToUpper());
                            Console.WriteLine("\tTotal de Puntos Vive Colombia: {0}", puntos);

                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("\tCanje de puntos ViveColombia.");
                            
                            puntos = _objUsuario.ConsultarPuntosViveColombia(idUser: idUser);
                            
                            Console.Write("\tPor favor ingrese los puntos a Canjear: ");
                            float puntosCanjear = float.Parse(Console.ReadLine());

                            if (puntosCanjear < puntos)
                            {
                                Console.WriteLine("\tError: No se pueden canjear tus puntos.");
                                Console.WriteLine("\tError: Por favor revisa el valor ingresado.");
                            }else if (puntosCanjear > puntos)
                            {
                                Console.WriteLine("\tError: No se pueden canjear tus puntos.");
                                Console.WriteLine("\tError: Por favor revisa el valor ingresado.");
                            }
                            else
                            {
                                _objUsuario.CanjearPuntosViveColombia(idUser: idUser, puntos: puntosCanjear);
                                Console.WriteLine("\tLos puntos de canjearon exitosamente.");
                            }
                            
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.WriteLine("\tSalio del Cajero Automatico correctamente.\n");
                            isSalir = false;
                            break;
                        default:
                            Console.WriteLine("\tPor favor seleccione una opcion válida.\n");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException error)
                {
                    Console.WriteLine("Por favor ingresa un valor válido. {0}", error.Message);
                    Console.ReadKey();
                }
                catch (ArgumentOutOfRangeException error)
                {
                    Console.WriteLine("El rango del número ingresado no es correcto, por favor valide de nuevo. {0}",
                        error.Message);
                    Console.ReadKey();
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error inesperado.. {0}", error.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}