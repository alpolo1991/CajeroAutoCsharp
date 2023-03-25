namespace CajeroAutomatico.Usuario
{
    internal class Usuario
    {
        private int _idUsuario;
        private String _nombre;
        private String _apellido;
        private string _username;
        private string _password;
        private String _direccion;
        private int _telefono;
        private String _numeroCuenta;
        private float _saldoC;
        private float _puntosVivaColombia;
        private float _limiteRetiro;

        private List<Usuario> Usuarios;

        public Usuario()
        {
            Usuarios = new List<Usuario>();

            Usuarios.Add(new Usuario(1, "Alfonso", "Gonzalez", "alfonso", "123456", "Cra 31 N 85 - 78", 31245678, "180219-76", 3000000, 10, 0));
            Usuarios.Add(new Usuario(2, "Tatiana", "Lopez", "tatiana", "123", "Cra 31 N 85 - 78", 31245679, "290219-76", 2500000, 20, 0));
        }

        public Usuario(int idUsuario, string nombre, string apellido, string username, string password,
            string direccion, int telefono, string numeroCuenta, float saldoC, int puntosVivaColombia, float limiteretiro)
        {
            _idUsuario = idUsuario;
            _nombre = nombre;
            _apellido = apellido;
            _username = username;
            _password = password;
            _direccion = direccion;
            _telefono = telefono;
            _numeroCuenta = numeroCuenta;
            _saldoC = saldoC;
            _puntosVivaColombia = puntosVivaColombia;
            _limiteRetiro = limiteretiro;
        }

        public int IdUsuario
        {
            get => _idUsuario;
            set => _idUsuario = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Apellidos
        {
            get => _apellido;
            set => _apellido = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Username
        {
            get => _username;
            set => _username = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Password
        {
            get => _password;
            set => _password = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Direccion
        {
            get => _direccion;
            set => _direccion = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Telefono
        {
            get => _telefono;
            set => _telefono = value;
        }
        
        public string NumeroCuenta
        {
            get => _numeroCuenta;
            set => _numeroCuenta = value ?? throw new ArgumentNullException(nameof(value));
        }

        public float SaldoC
        {
            get => _saldoC;
            set => _saldoC = value;
        }
        
        public float PuntosVivaColombia
        {
            get => _puntosVivaColombia;
            set => _puntosVivaColombia = value;
        }

        public float LimiteRetiroDiarioU
        {
            get => _limiteRetiro;
            set => _limiteRetiro = value;
        }

        override
            public String ToString()
        {
            return "Usuario: ID -> " + IdUsuario + " " +
                   "[" +
                   "\n Nombre: " + Nombre +
                   "\n Apellidos: " + Apellidos +
                   "\n Dirección: " + Direccion +
                   "\n Username: " + Username +
                   "\n Telefono: " + Telefono +
                   "\n Numero Cuenta: " + NumeroCuenta +
                   "\n Saldo: $ " + SaldoC +
                   "\n Puntos Viva Colombia Disponibles: " + PuntosVivaColombia +
                   "\n Total Retirado Diario " + LimiteRetiroDiarioU +
                   "\n]";
        }
        
        public void ListarUsuarios()
        {
            for (int i = 0; i < Usuarios.Count; i++)
            {
                Console.Write("\n" + Usuarios[i]);
            }
        }
        
        /*
        public void ListarUnUsuario(int idUser)
        {
            bool encontrado = false;
            for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    Console.WriteLine(Usuarios[i] + " ");
                    encontrado = true;
                }
            }
        }

        public void RecuperarPassword(int idUser, string newpassword)
        {
            foreach (var usuario in Usuarios)
            {
                if (usuario.IdUsuario == idUser)
                {
                    usuario.Password = newpassword;
                    Console.WriteLine("Se modifico contraseñas correctamente.");
                    Console.WriteLine("Username: {0}\n Nueva Contraseña: {1}", usuario.Username, usuario.Password);
                }
            }
        }
   

        public Usuario Buscar_Un_usuario(int idUser)
        {
            Usuario buscada = null;
            bool encontrado = false;
            for (int i = 0; i < Usuarios.Count && encontrado == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    buscada = Usuarios[i];
                    encontrado = true;
                }
            }

            return buscada;
        }
        */

        public bool ExisteUser(string username)
        {
            bool isExiste = false;
            foreach (Usuario usuario in Usuarios)
            {
                if (usuario.Username.Equals(username))
                {
                    isExiste = true;
                }
            }

            return isExiste;
        }

        public void AgregarUnUsuario(int idUser, string nombre, string apellido, string username, string password,
            string direccion, int telefono, string numerodecuenta, float saldoc, int puntosvivaColombia, float limiteretiro)
        {
            Usuario nueva = new Usuario(idUser, nombre, apellido, username, password, direccion, telefono, numerodecuenta, saldoc, puntosvivaColombia, limiteretiro);
            Usuarios.Add(nueva);
        }

        public bool Login(string username, string password)
        {
            bool isLogin = false;
            for (int i = 0; i < Usuarios.Count && isLogin == false; i++)
            {
                if (Usuarios[i].Username.Equals(username))
                {
                    if (Usuarios[i].Password.Equals(password))
                    {
                        isLogin = true;
                    }
                }
            }

            return isLogin;
        }

        public int ObtenerIDUser(string username)
        {
            int GetIDUser = 0;
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].Username == username)
                {
                    GetIDUser = Usuarios[i].IdUsuario;
                    isSeEncontro = true;
                }
            }

            return GetIDUser;
        }

        public bool RecuperarUsernamePass(string username)
        {
            bool isCorrectPass = false;
            foreach (var usuario in Usuarios)
            {
                if (usuario.Username == username)
                {
                    if (usuario.Username == username && usuario.IdUsuario == usuario.IdUsuario)
                    {
                        isCorrectPass = true;
                    }
                }
            }

            return isCorrectPass;
        }

        public void RecuperarUserPass(int idUser, string newusername, string newpassword)
        {
            foreach (var usuario in Usuarios)
            {
                if (usuario.IdUsuario == idUser)
                {
                    usuario.Username = newusername;
                    usuario.Password = newpassword;
                    Console.WriteLine("El usuario {0} se modifico correctamente.", usuario.Username);
                }
            }
        }

        public int TotalUsuarios()
        {
            int ContarUsuarios = 0;
            for (int i = 0; i < Usuarios.Count; i++)
            {
                ContarUsuarios++;
            }

            return ContarUsuarios;
        }

        public float AgregarSaldo(int idUser, float saldoAgregar)
        {
            float saldoCuenta = 0;
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    Usuarios[i].SaldoC += saldoAgregar;
                    saldoCuenta = Usuarios[i].SaldoC;
                    isSeEncontro = true;
                }
            }
            return saldoCuenta;
        }
        
        public float RetirarSaldo(int idUser, float saldoRetirar)
        {
            float saldoCuenta = 0;
            foreach (var usuario in Usuarios)
            {
                if (usuario.IdUsuario == idUser)
                {
                    usuario.SaldoC -= saldoRetirar;
                    saldoCuenta = usuario.SaldoC;
                }
            }
            return saldoCuenta;
        }

        public float EnviarSaldo(string numerocuenta, float enviarsaldo)
        {
            float enviarSaldo = 0;
            foreach (var usuario in Usuarios)
            {
                if (usuario.NumeroCuenta.Equals(numerocuenta))
                {
                    usuario.SaldoC += enviarsaldo;
                    enviarSaldo = usuario.SaldoC;
                }
            }
            return enviarSaldo;
        }
        
        public float ConsultarSaldo(int idUser)
        {
            float saldoConsultar = 0;
            foreach (var usuario in Usuarios)
            {
                if (usuario.IdUsuario == idUser)
                {
                    saldoConsultar = usuario.SaldoC;
                }
            }
            return saldoConsultar;
        }
        
        public bool ValidarCuenta(string numeroCuenta)
        {
            bool isCuenta = false;
            foreach (var usuario in Usuarios)
            {
                if (usuario.NumeroCuenta.Equals(numeroCuenta))
                {
                    isCuenta = true;
                }
            }
            return isCuenta;
        }
        
        public bool ValidarCuentaUser(int idUser, string numeroCuenta)
        {
            bool isCuenta = false;
            foreach (var usuario in Usuarios)
            {
                if (usuario.IdUsuario == idUser)
                {
                    if (usuario.NumeroCuenta.Equals(numeroCuenta))
                    {
                        isCuenta = true;
                    }
                }
            }
            return isCuenta;
        }

        public float ConsultarPuntosViveColombia(int idUser)
        {
            float puntos = 0;
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    puntos = Usuarios[i].PuntosVivaColombia;
                    isSeEncontro = true;
                }
            }
            return puntos;
        }
        
        public void AgregarPuntosViveColombia(int idUser)
        {
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    Usuarios[i].PuntosVivaColombia += 1;
                    isSeEncontro = true;
                }
            }
        }

        public void LimiteRetiroUDiario(int idUser, float saldoretirado)
        {
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    Usuarios[i].LimiteRetiroDiarioU += saldoretirado;
                    isSeEncontro = true;
                }
            }
        }

        public float LimiteRetiroUsDiario(int idUser)
        {
            float LimiteRetiroUsDiario = 0;
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    LimiteRetiroUsDiario = Usuarios[i].LimiteRetiroDiarioU;
                    isSeEncontro = true;
                }
            }
            return LimiteRetiroUsDiario;
        }

        public void CanjearPuntosViveColombia(int idUser, float puntos)
        {
            bool isSeEncontro = false;
            for (int i = 0; i < Usuarios.Count && isSeEncontro == false; i++)
            {
                if (Usuarios[i].IdUsuario == idUser)
                {
                    Usuarios[i].PuntosVivaColombia -= puntos;
                    isSeEncontro = true;
                }
            }
        }
        
        
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
        
        public void OperarCajeroU(string user, int idUser)
        {
            
            Console.Clear();
            Console.WriteLine("\t\t##===================================##");
            Console.WriteLine("\t\t##\tUsuario: {0}             ##", user.ToUpper());
            Console.WriteLine("\t\t##\tId Usuario: {0}                ##", idUser);
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
                            Saldo = ConsultarSaldo(idUser: idUser);
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
                                Saldo = AgregarSaldo(idUser: idUser, saldoAgregar: saldoIngresar);
                                AgregarPuntosViveColombia(idUser: idUser);
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
                            SaldoRetirado = LimiteRetiroUsDiario(idUser: idUser);
                            if (saldoRetirar >= Saldo)
                            {
                                Console.WriteLine("\tEl valor a retirar no puede ser mayor al saldo disponible.");
                                Console.WriteLine("\tPor favor ingrese otro valor.");
                            }
                            else if (SaldoRetirado.Equals(LimiteDiarioRetiro))
                            {
                                Console.WriteLine("\tLimite de retiro diario alcanzado por cajero.");
                                Console.WriteLine("\tPor favor acercarse a caja.");
                            }else if (saldoRetirar <= 0)
                            {
                                Console.WriteLine("\tPor favor ingrese un saldo válido.");
                            }
                            else
                            {
                                Saldo = RetirarSaldo(idUser: idUser, saldoRetirar: saldoRetirar);                             
                                LimiteRetiroUDiario(idUser: idUser, saldoretirado: saldoRetirar);
                                AgregarPuntosViveColombia(idUser: idUser);
                             
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
                            
                            bool validarCuenta = ValidarCuenta(numeroCuenta: cuentaDestino);

                            if (validarCuenta)
                            {
                                bool validarCuentaUser = ValidarCuentaUser(idUser: idUser, numeroCuenta: cuentaDestino);
                                if (!validarCuentaUser)
                                {
                                    Console.Write("\tPor favor ingrese el monto a enviar: ");
                                    float montoEnviar = Int32.Parse(Console.ReadLine());
                                    Saldo = ConsultarSaldo(idUser: idUser);

                                    if (montoEnviar >= Saldo)
                                    {
                                        Console.WriteLine("\tError: El valor a enviar no puede ser mayor que el de tu cuenta.");
                                    }else if (montoEnviar <= 0)
                                    {
                                        Console.WriteLine("\tError: El valor a enviar no puede ser negativo o cero.");
                                    }
                                    else
                                    {
                                        EnviarSaldo(numerocuenta: cuentaDestino, enviarsaldo: montoEnviar);
                                        Saldo = RetirarSaldo(idUser: idUser, saldoRetirar: montoEnviar);
                                        AgregarPuntosViveColombia(idUser: idUser);
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
                            float puntos = ConsultarPuntosViveColombia(idUser: idUser);
                            Console.WriteLine("\tPara el Usuario: {0}", user.ToUpper());
                            Console.WriteLine("\tTotal de Puntos Vive Colombia: {0}", puntos);

                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("\tCanje de puntos ViveColombia.");
                            
                            puntos = ConsultarPuntosViveColombia(idUser: idUser);
                            
                            Console.Write("\tPor favor ingrese los puntos a Canjear: ");
                            float puntosCanjear = float.Parse(Console.ReadLine());

                            if (puntosCanjear <= 0)
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
                                CanjearPuntosViveColombia(idUser: idUser, puntos: puntosCanjear);
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